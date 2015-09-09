using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentB.Interface;

namespace AssignmentB.Rules
{
    class LayOverTimeFactor:IGetDiscountingFactor
    {
        public decimal GetDiscountFactor(Itinerary netRate)
        {
            var layOverTime = (decimal)netRate.TotalLayoverTime.TotalHours - (decimal)Itinerary.MinimunTotalLayoverTime.TotalHours;

            return 1 / ((decimal)Itinerary.MaximumTotalLayoverTime.TotalHours - (decimal)Itinerary.MinimunTotalLayoverTime.TotalHours) * layOverTime; ;
        }
    }
}
