using MyApp.Beacon;
using MyApp.JourneyDetection;
using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; using Xamarin.Forms;  namespace MyApp.Std
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }




        private Journey.Journey mJourney = new Journey.Journey();
        private JourneyDetectorICE mDetector;
        public void initJourneyDetector()
        {
            mDetector = new JourneyDetectorICE();
            mDetector.TrainStarted += handleTrainStartDetected;
        }

        private void handleTrainStartDetected(object o, TrainEventArgs a)
        {
            mJourney.startJourneyWithICE(a.startLocation, a.startTime, a.beaconIdOnEnter, a.trainId);
            DisplayAlert("Alert", "Train started", "OK");
        }

        private async void ViewCurrentRide_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewCurrentRide());
        }

        private async void ViewAccountBalance_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewAccountBalance());
        }

        private async void TopUpAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopUpAccount());
        }

        private async void ViewMyRides_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewMyRides());
        }

        private async void ViewGeneral_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewGeneral());
        }

        private async void ViewBeacons_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewBeacons());
        }



        private void BePrepared_Clicked(object sender, EventArgs e)
        {
            initJourneyDetector();
        }

    }//end class
}//end namesapce
