using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentB.Rules;

namespace AssignmentB
{
    public class Driver
    {
        public decimal ApplyFactors(Itinerary netRate)
        {
            FlightTimeFactor flightTimeFactor = new FlightTimeFactor();
            LayOverTimeFactor layOverTimeFactor = new LayOverTimeFactor();
            NumberOfStopsFactor numberOfStopsFactor = new NumberOfStopsFactor();

            var flightTimeInfluence = flightTimeFactor.GetDiscountFactor(netRate);
            var layOverTimeInfluence = layOverTimeFactor.GetDiscountFactor(netRate);
            var numberOfStopsInfluence = numberOfStopsFactor.GetDiscountFactor(netRate);

            var cumulativeInfluence = Math.Round((flightTimeInfluence + layOverTimeInfluence + numberOfStopsInfluence), 2);
            return cumulativeInfluence;
        }

    }
}
