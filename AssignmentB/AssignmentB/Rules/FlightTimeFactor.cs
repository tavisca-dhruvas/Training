using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentB.Interface;

namespace AssignmentB.Rules
{
    class FlightTimeFactor:IGetDiscountingFactor
    {
        public decimal GetDiscountFactor(Itinerary netRate)
        {
            var flightTime = (decimal)netRate.FlightTime.TotalHours - (decimal)Itinerary.MinimumFlightTime.TotalHours;
            return 1 / ((decimal)Itinerary.MaximumFlightTime.TotalHours - (decimal)Itinerary.MinimumFlightTime.TotalHours) * flightTime;
        }

    }
}
