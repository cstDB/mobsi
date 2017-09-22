﻿using MyApp.Std;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyApp.Beacon;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Collections.Specialized;

namespace MyApp.JourneyDetection
{
    public class JourneyDetectorICE
    {

        bool mTrainStarted;
        public ObservableCollection<SharedBeacon> Beacons { get; set; } = new ObservableCollection<SharedBeacon>();
        public event EventHandler TrainStarted;

        public JourneyDetectorICE()
        {
            initBeaconListener();
            initZIP();

            initEvents();
        }

        protected virtual void OnTrainStarted(EventArgs e)
        {
            if (TrainStarted != null)
                TrainStarted(this, e);
        }

        private void initBeaconListener()
        {
            App.mBeaconHandler.BeaconListChanged += (sender, e) => {
                foreach (SharedBeacon beacon in e.Data)
                {
                    if (!Beacons.Any(x => x.BeaconId == beacon.BeaconId)){
                        beacon.Added = DateTime.Now;
                        Beacons.Add(beacon);
                    }
                }
            };

            //TODO StartRanging eleganter lösen
            //wenn man in der App navigiert, wird sonst das startranging nicht wieder eingeschaltet, weil OnConnectedService schon durch war.
            App.mBeaconHandler.StartRanging();

            //TODO  App.mBeaconMonitor.BeaconListChanged -=
        }


        private void initZIP()
        {
            //TODO
        }


        private void initEvents()
        {
            Beacons.CollectionChanged += beaconChangedHandler;
        }
        
        private void beaconChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!mTrainStarted)
            {
                Device.StartTimer(TimeSpan.FromSeconds(-10), () => { return handleTimer(); });
            }
            
        }

        
        private bool handleTimer()
        {
            mTrainStarted = trainStarted();
            if (mTrainStarted) OnTrainStarted(new EventArgs());
            //True = Repeat again, False = Stop the timer
            return !mTrainStarted; //wenn wir einen Zug haben, hören wir auf zu prüfen ob wir losgefahren sind
        }

        private bool trainStarted() {
            bool trainDrivingWLAN = true; //TODO Michael
            foreach (SharedBeacon beacon in Beacons)
            {
                if (DateTime.Now.AddSeconds(-10) >= beacon.Added) { 
                    if (trainDrivingWLAN) {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                } else
                {
                    return false;
                }
            }
            return false;
        }



    }//end class
}//end namespace