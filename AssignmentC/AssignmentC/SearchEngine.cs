using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC
{
    public class SearchEngine
    {
        public List<Itinerary> Process(List<Itinerary> discounted)
        {
            Regulation regulation = new Regulation();
            var weightedItinerary = regulation.ApplyRules(discounted);
            FilterSearch filterSearch = new FilterSearch();

            filterSearch.FilterAirResults(weightedItinerary);
            SortResults sortResults = new SortResults();
            return sortResults.SortingAirResults(weightedItinerary);

        }
    }
}
