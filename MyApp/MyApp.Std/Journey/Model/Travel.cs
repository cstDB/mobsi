using MyApp.Journey.Model.Medium;
using System;

namespace MyApp.Journey.Model
{
    enum Status
    {
        FINISHED,
        IN_PROGRESS
    }

    class Travel
    {
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Coord startLocation { get; set; }
        public Coord endLocation { get; set; }
        public TravelICE Medium { get; set; }

    }
}
