using MyApp.Beacon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyApp.Std
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();


            //MainPage = new MyApp.Std.MainPage();
            MainPage = new NavigationPage(new MainPage()); //damit man neue Pages aufmachen kann


        }

        //TODO ordentlichen Singleton aus BeaconHandler machen
        public static IBeaconHandler mBeaconHandler;
        protected override void OnStart()
        {
            mBeaconHandler = DependencyService.Get<IBeaconHandler>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
