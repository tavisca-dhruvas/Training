using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentB.Interface;

namespace AssignmentB.Rules
{
    class NumberOfStopsFactor:IGetDiscountingFactor
    {
        public decimal GetDiscountFactor(Itinerary netRate)
        {
            var stops = (decimal)netRate.NumberOfStops;
            return 1 / (decimal)Itinerary.MaxStops * stops;
        }
    }
}
