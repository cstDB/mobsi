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
using MyApp.Std;

namespace MyApp
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ViewBeacons : ContentPage
  {

    public ViewBeacons()
    {

      //Beacons.Add(new SharedBeacon { BeaconId = "sdggadfdfgafdfddfa", MacAddress = "FSFSDFsdsd"  , Distance = "10" });
      this.BindingContext = this;

      InitializeComponent();

      initBeaconListener();
    }

    public ObservableCollection<SharedBeacon> Beacons { get; set; } = new ObservableCollection<SharedBeacon>();
    public string Logs { get; set; } = "";

    private void initBeaconListener() {

       App.mBeaconHandler.BeaconListChanged += (sender, e) => {
        Beacons.Clear();
        foreach (SharedBeacon beacon in e.Data)
        {
          Beacons.Add(beacon);
        }

        Logs = Logs + "\n" + DateTime.Now.ToString(DateTimeFormatInfo.CurrentInfo.ShortTimePattern) + " - BeaconListChanged - #Beacons = " + Beacons.Count;
        OnPropertyChanged(nameof(Logs));
      };

      //TODO StartRanging eleganter lösen
      //wenn man in der App navigiert, wird sonst das startranging nicht wieder eingeschaltet, weil OnConnectedService schon durch war.
      App.mBeaconHandler.StartRanging();

      //TODO  App.mBeaconMonitor.BeaconListChanged -=

    }

  }//end class
}//end namespace