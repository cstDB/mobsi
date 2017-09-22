using MyApp.Journey.Model;
using MyApp.Journey.Model.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Journey
{
    class Journey
    {

        public Travel startJourneyWithICE(Coord startLocation, DateTime startTime, string beaconIdOnEnter, string trainId)
        {
            if (getCurrentJourney() != null)
            {
                throw new Exception("There is already a journey started!");
            }

            Travel travel = new Travel();
            travel.startLocation = startLocation;
            travel.StartTime = startTime;
            travel.Status = Status.FINISHED;

            travel.Medium = new TravelICE();
            travel.Medium.TrainId = trainId;
            travel.Medium.BeaconIdOnEnter = beaconIdOnEnter;

            Store.Storage.Add(travel);
            
            return travel;
        }

        public Travel getCurrentJourney()
        {
            Travel retVal = null;

            foreach (Travel travel in Store.Storage)
            {
                if (retVal.Status == Status.IN_PROGRESS)
                {
                    retVal = travel;
                    break;
                }
            }

            return retVal;
        }

    }
}
