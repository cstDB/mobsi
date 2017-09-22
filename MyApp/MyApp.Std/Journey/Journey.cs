using MyApp.Journey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Journey
{
    class Journey
    {


        List<Travel> allJourneys { get; set; }


        public bool startJourneyWithICE(Coord startLocation, DateTime startTime, string beaconIdOnEnter, string trainId)
        {
            Travel travel = new Travel();
            travel.startLocation = startLocation;
            travel.StartTime = startTime;
            travel.Medium = new TravelICE();
            //travel.Medium
                       
            return true;
        }

        public Travel actualJourneyMock()
        {
            Travel mock = new Travel();
            mock.startLocation.Desc = "Frankfurt/Main";
            mock.Status = Status.IN_PROGRESS;
            mock.Medium = "ICE";
            mock.StartTime = new DateTime();       


        }


    }
}
