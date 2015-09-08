using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC
{
    class FilterSearch
    {
        public  Dictionary<Itinerary,int> FilterAirResults(Dictionary<Itinerary, int> weightedItinerary)
        {
            for (int i = 0; i < weightedItinerary.Count(); i++)
            {
                if (weightedItinerary.ElementAt(i).Value == -1)
                {
                    weightedItinerary.Remove(weightedItinerary.ElementAt(i).Key);
                }

            }
            return weightedItinerary;
        }
    }
}
