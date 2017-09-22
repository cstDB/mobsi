using System;
using AltBeaconOrg.BoundBeacon;
using Android.Widget;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Android.App;
using MyApp.Beacon;
using Android.Content;
using Android.Support.V4.App;
using AltBeaconOrg.BoundBeacon.Powersave;
using Android.Util;
using AltBeaconOrg.BoundBeacon.Startup;
using Android;
using Android.Content.PM;

[assembly: Xamarin.Forms.Dependency(typeof(MyApp.Droid.Beacon.BeaconHandler))]
namespace MyApp.Droid.Beacon
{
  public class BeaconHandler : Java.Lang.Object, MyApp.Beacon.IBeaconHandler, IBootstrapNotifier, IRangeNotifier
  {

    public Context ApplicationContext { get { return Xamarin.Forms.Forms.Context; } }

    private BeaconManager mBeaconManager;

    private const string TAG = "AltBeaconService";
    private const int cMillisForegroundBetweenScanPeriod = 5000;

    private RegionBootstrap mRegionBootstrap;
    private BackgroundPowerSaver mBackgroundPowerSaver;
    Region mAnyRegion = new AltBeaconOrg.BoundBeacon.Region("AnyBeaconId", null, null, null);

    public event EventHandler<BeaconListChangedEventArgs> BeaconListChanged;

    public BeaconHandler()
    {
  
           initService();
    }

   

        private void initService() {

      mBeaconManager = BeaconManager.GetInstanceForApplication(Xamarin.Forms.Forms.Context);

      var iBeaconParser = new BeaconParser();
      iBeaconParser.SetBeaconLayout("m:2-3=0215,i:4-19,i:20-21,i:22-23,p:24-24"); //default for modern beacons
      mBeaconManager.BeaconParsers.Add(iBeaconParser);

      //bind to MainActivity
      MainActivity ma = ((MainActivity)ApplicationContext);
      ma.mBeaconHandler = this;
      mBeaconManager.Bind((IBeaconConsumer)ma);

      // wake up the app when a beacon is seen
      mRegionBootstrap = new RegionBootstrap(this, mAnyRegion);

      // simply constructing this class and holding a reference to it in your custom Application
      // class will automatically cause the BeaconLibrary to save battery whenever the application
      // is not visible.  This reduces bluetooth power usage by about 60%
      mBackgroundPowerSaver = new BackgroundPowerSaver(ApplicationContext);

    }




    public void StartMonitoring()
    {
      mBeaconManager.SetForegroundBetweenScanPeriod(cMillisForegroundBetweenScanPeriod);

      mBeaconManager.AddMonitorNotifier(this);
      mBeaconManager.StartMonitoringBeaconsInRegion(mAnyRegion);
    }

    public void StopMonitoring()
    {
      mBeaconManager.RemoveAllMonitorNotifiers();
      mBeaconManager.StopMonitoringBeaconsInRegion(mAnyRegion);
    }

    public void StartRanging()
    {
      mBeaconManager.SetForegroundBetweenScanPeriod(cMillisForegroundBetweenScanPeriod);

      mBeaconManager.AddRangeNotifier(this);
      mBeaconManager.StartRangingBeaconsInRegion(mAnyRegion);
    }

    public void StopRanging()
    {
      mBeaconManager.RemoveAllRangeNotifiers();
      mBeaconManager.StopRangingBeaconsInRegion(mAnyRegion);
    }



   
    public void DidRangeBeaconsInRegion(ICollection<AltBeaconOrg.BoundBeacon.Beacon> beacons, Region region)
    {

      EventHandler<BeaconListChangedEventArgs> handler = BeaconListChanged;
      if (handler != null  && beacons != null && beacons.Count > 0)
      {
        List<SharedBeacon> data = new List<SharedBeacon>();
        foreach(AltBeaconOrg.BoundBeacon.Beacon beacon in beacons) { 
          data.Add(new SharedBeacon { BeaconId = beacon.Id1.ToString(),
                                      Distance = string.Format("{0:N2}m", beacon.Distance),
                                      MacAddress = beacon.BluetoothAddress,
                                      Major = beacon.Id2.ToString(),
                                      Minor = beacon.Id3.ToString(),
          });
        }
        handler(this, new BeaconListChangedEventArgs(data));

        //DidRangeBeaconsInRegion - Called once per second to give an estimate of the mDistance to visible beacons
        //deswegen schalten wir es wieder aus, wenn es nichts neues abzusuchen gibt (siehe DidEnterRegion und DidExitRegion)
        this.StopRanging();
      }

    }

    public void DidDetermineStateForRegion(int state, AltBeaconOrg.BoundBeacon.Region region)
    {
      //Called with a state value of MonitorNotifier.INSIDE when at least one beacon in a Region is visible.
      //brauchen wir nicht
    }

    public void DidEnterRegion(AltBeaconOrg.BoundBeacon.Region region)
    {
      Log.Debug(TAG, "did enter region.");
      this.StartRanging(); 
      
      //TODO SendNotification wieder aufnehmen für schlafende Cells
      //SendNotification();
    }

    public void DidExitRegion(AltBeaconOrg.BoundBeacon.Region region)
    {
      Log.Debug(TAG, "did exit region.");
      this.StartRanging(); 
    }


    private void SendNotification()
    {
      var builder =
        new NotificationCompat.Builder(ApplicationContext)
          .SetContentTitle("AltBeacon Reference Application")
          .SetContentText("A beacon is nearby.")
          .SetSmallIcon(Android.Resource.Drawable.IcDialogInfo);

      var stackBuilder = Android.App.TaskStackBuilder.Create(ApplicationContext);
      stackBuilder.AddNextIntent(new Intent(Xamarin.Forms.Forms.Context, typeof(MainActivity)));
      var resultPendingIntent =
        stackBuilder.GetPendingIntent(
          0,
          PendingIntentFlags.UpdateCurrent
        );
      builder.SetContentIntent(resultPendingIntent);
      var notificationManager =
        (NotificationManager)ApplicationContext.GetSystemService(Context.NotificationService);
      notificationManager.Notify(1, builder.Build());
    }

   
    public void myDispose()
    {
      this.StopMonitoring();
      this.StopRanging();
      mBeaconManager.Unbind((MainActivity)ApplicationContext);
      mBeaconManager.UnregisterFromRuntime();
      mBeaconManager.Dispose();
    }

  }//end clas
}//end namespace