using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MyApp.Std;
using MyApp.Droid;
using AltBeaconOrg.BoundBeacon;
using MyApp.Beacon;
using AltBeaconOrg.BoundBeacon.Startup;
using MyApp.Droid.Beacon;
using Android.Content;


using Android.Support.V4.App;
using AltBeaconOrg.BoundBeacon.Powersave;
using Android.Util;
using Android;

namespace MyApp.Droid
{
  [Activity(Label = "mobsi", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IBeaconConsumer
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);


      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new App());

      


    }

        static string[] PERMISSIONS = {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
};


        public MyApp.Droid.Beacon.BeaconHandler mBeaconHandler; //wird vom Service selber gesetzt. Irgendwie doof aber egal.
    public void OnBeaconServiceConnect()
    {

            if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                RequestPermissions(PERMISSIONS, 0);
            }

            mBeaconHandler.StartMonitoring();

      //https://community.estimote.com/hc/en-us/articles/203356607-What-are-region-Monitoring-and-Ranging-
      mBeaconHandler.StartRanging(); 
    }

    protected override void OnDestroy()
    {
      mBeaconHandler.myDispose();
      mBeaconHandler = null;
    }

    //protected override void OnResume()
    //{
    //  //if (mBeaconHandler != null) mBeaconHandler.StartMonitoring();
    //}

  }//end class
}//end namespace

