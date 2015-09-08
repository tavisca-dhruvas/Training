using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC
{
    class SortResults
    {
        public List<Itinerary> SortingAirResults(Dictionary<Itinerary, int> weightedItineray)
        {
           
            var flights = weightedItineray.OrderByDescending(fair => fair.Value)
                 .ThenBy(fare => fare.Key.MarkupInUSD)
               .ThenBy(fare => fare.Key.NumberOfStops);
   
                var sortedResults = flights.Select(kvp => kvp.Key).ToList();

                return sortedResults;
            
        }
    }
}
