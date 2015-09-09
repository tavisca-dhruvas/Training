
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentB.Rules;

namespace AssignmentB
{
    public class MarkupCalculator
    {
        public MarkupCalculator(decimal distributionCost = 10m, decimal minDiscount = 0)
        {
            DistributionCost = distributionCost;
            MinDiscount = minDiscount;
        }

        public decimal DistributionCost { get; set; }

        public decimal MinDiscount { get; set; }

        

        public decimal Getmarkup(Itinerary published, Itinerary netRate)
        {
            Driver driverObject = new Driver();
            var discountedAmount = published.BaseFareInUSD - MinDiscount;
            var netExpenditure = netRate.BaseFareInUSD;
            var maxMarkup = discountedAmount - netExpenditure;

            if (maxMarkup < DistributionCost)
                throw new FinanciallyUnviableRateException("This Rate is not  viable ");
            var maxMargin = maxMarkup - DistributionCost;
            var cumulativeFactor = driverObject.ApplyFactors(netRate);
            return (maxMarkup - (maxMargin *cumulativeFactor));

        }
      
       

       
        
    }
}
