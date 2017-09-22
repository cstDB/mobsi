using System;
using System.Diagnostics;
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
      public string currentJourneyStart { get; set; }
      public string currentJourneyId { get; set; }
      public string currentJourneyStartDate { get; set; }
      private MyApp.Journey.Journey test = new MyApp.Journey.Journey();

      public ViewCurrentRide()
      {
         this.BindingContext = this;

         InitializeComponent();
         //actualJourney();



      }


      private void actualJourney()
      {
         /*
         MyApp.Journey.Journey test = new MyApp.Journey.Journey();
         MyApp.Journey.Model.Coord testCoord = new Journey.Model.Coord();
         testCoord.Desc = "Frankfurt/Main";
         try
         {
            test.startJourneyWithICE(testCoord, DateTime.Now, "0815", "Zug 0815");
         }
         catch (Exception e)
         {
            Debug.WriteLine("We are traveling already...");
         }*/

         currentJourney = test.getCurrentJourney();
         updateStringProperties();
      }


      private void updateStringProperties()
      {
         currentJourneyStart = currentJourney.startLocation.Desc;
         OnPropertyChanged(nameof(currentJourneyStart));

         currentJourneyId = currentJourney.Medium.TrainId;
         OnPropertyChanged(nameof(currentJourneyId));

         currentJourneyStartDate = currentJourney.StartTime.ToString("dd.MM.yyyy");
         OnPropertyChanged(nameof(currentJourneyStartDate));
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