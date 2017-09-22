using MyApp.Journey.Model;
using MyApp.Journey.Model.Medium;
using System;

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

        /**
         * Copied from https://stackoverflow.com/questions/6366408/calculating-distance-between-two-latitude-and-longitude-geocoordinates#6366657
         */
        private Int16 calculateDistance(Coord startLocation, Coord endLocation)
        {
            var baseRad = Math.PI * startLocation.Latitude / 180;
            var targetRad = Math.PI * endLocation.Latitude / 180;
            var theta = startLocation.Longitude - endLocation.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            
            return (Int16)Math.Floor(dist * 1.609344);
        }

        public void endJourneyWithICE(Coord endLocation, DateTime endTime, string beaconOnLeave)
        {
            Travel travel = this.getCurrentJourney();
            if (travel == null)
            {
                throw new Exception('There is no journey started');
            }

            travel.endLocation = endLocation;
            travel.EndTime = endTime;
            travel.Medium.BeaconIdOnLeave = beaconOnLeave;
            travel.Medium.travelledDistanceInKM = this.calculateDistance(travel.startLocation, travel.endLocation);
            travel.Status = Status.FINISHED;

            int index = Store.Storage.IndexOf(travel);
            if (index >= 0)
            {
                Store.Storage[index] = travel;
            }
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
