using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB
{
    public class Itinerary
    {
        
        public string OriginAirportCode { get; set; }

        public string DestinationAirportCode { get; set; }

        public TimeSpan FlightTime { get; set; }

        public int NumberOfStops { get; set; }

        public TimeSpan TotalLayoverTime { get; set; }

        public string Airline { get; set; }

        public DateTime UtcDepartureTime { get; set; }

        public DateTime UtcArrivalTime { get; set; }

        public decimal BaseFareInUSD { get; set; }

        public decimal MarkupInUSD { get; set; }

        public decimal TotalFareInUSD { get { return this.BaseFareInUSD + this.MarkupInUSD; } }

        public static readonly int MaxStops = 5;

        public static readonly TimeSpan MinimumFlightTime = new TimeSpan(1, 0, 0);

        public static readonly TimeSpan MaximumFlightTime = new TimeSpan(24, 0, 0);

        public static readonly TimeSpan MinimunTotalLayoverTime = new TimeSpan(0, 15, 0);

        public static readonly TimeSpan MaximumTotalLayoverTime = new TimeSpan(1, 0, 0);
    }



}
