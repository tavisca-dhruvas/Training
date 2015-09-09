using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB.Interface
{
    interface IGetDiscountingFactor
    {
        decimal GetDiscountFactor(Itinerary netRate);
    }
}
