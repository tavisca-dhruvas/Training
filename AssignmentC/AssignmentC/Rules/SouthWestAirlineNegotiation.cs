using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC.Rules
{
    public class SouthWestAirlineNegotiation : IGetValue
    {

        public Dictionary<Itinerary, int> IWeightGenerator(Dictionary<Itinerary, int> itineraryDictionary, int weight)
        {
            for (int i = 0; i < itineraryDictionary.Count() ; i++)
            {
                if ((itineraryDictionary.ElementAt(i).Key.OriginAirportCode == "Dallas"))
                {
                    if ((itineraryDictionary.ElementAt(i).Key.Airline == "SouthWest Airlines"))
                    {
                        weight += 1000;
                        itineraryDictionary[itineraryDictionary.ElementAt(i).Key] = weight;
                    }
                    else
                    {
                        weight = -1;
                        itineraryDictionary[itineraryDictionary.ElementAt(i).Key] = weight;
                    }
                }
            }
            return itineraryDictionary;
        }
    }
}
