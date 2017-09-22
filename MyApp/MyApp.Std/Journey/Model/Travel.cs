using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Journey.Model
{
    enum Status
    {
        FINISHED,
        IN_PROGRESS
    }

    enum TravelMethod
    {
        ICE
    }

    class Travel
    {
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TravelMethod TravelMethod { get; set; }
        public Coord startLocation { get; set; }
        public Coord endLocation { get; set; }

    }
}
