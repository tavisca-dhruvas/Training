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
                if ((weightedItinerary.ElementAt(i).Key.Airline == "SouthWest Airlines") && (weightedItinerary.ElementAt(i).Key.OriginAirportCode=="Dallas"))
                {
                    
                    for (int j = 0; j < weightedItinerary.Count(); j++)
                    {
                        if (weightedItinerary.ElementAt(j).Value == -1)
                        {
                            if ((weightedItinerary.ElementAt(i).Key.NumberOfStops == weightedItinerary.ElementAt(j).Key.NumberOfStops))
                            {
                                if (weightedItinerary.ElementAt(i).Key.ClassOfService == weightedItinerary.ElementAt(j).Key.ClassOfService)
                                    weightedItinerary.Remove(weightedItinerary.ElementAt(j).Key);

                            }
                            else
                            {
                                weightedItinerary[weightedItinerary.ElementAt(i).Key] = 0;
                            }
                        }
 
                    }
                }

            }
            return weightedItinerary;
        }
    }
}
