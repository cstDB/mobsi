using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyApp.Journey;

namespace MyApp
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ViewCurrentRide : ContentPage
  {
        public Journey.Model.Travel currentJourney { get; set; }

        public ViewCurrentRide()
    {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            };

            actualJourney();
    }
  

        private void actualJourney() {
            MyApp.Journey.Journey test = new MyApp.Journey.Journey();

            MyApp.Journey.Model.Coord testCoord = new Journey.Model.Coord();
            testCoord.Desc = "Frankfurt/Main";
            test.startJourneyWithICE(testCoord, new DateTime(), "0815", "Zug 0815" );

            currentJourney = test.getCurrentJourney();
        }

    private async void CorrectRide_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new CorrectRide());
    }

    private async void UpdateView1_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new UpdateView1());
    }
    
  }
}