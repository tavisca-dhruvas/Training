using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC.Rules
{
    public class AmericanAirlineNegotiation : IGetValue
    {

        public Dictionary<Itinerary, int> IWeightGenerator(Dictionary<Itinerary, int> itineraryDictionary, int weight)
        {
            for (int i = 0; i < itineraryDictionary.Count(); i++)
            {
                if ((itineraryDictionary.ElementAt(i).Key.UtcDepartureTime.Month == 12) && (itineraryDictionary.ElementAt(i).Key.RoundtripReturnTime.Month == 12))
                {
                    if (((itineraryDictionary.ElementAt(i).Key.RoundtripReturnTime.Day - itineraryDictionary.ElementAt(i).Key.UtcDepartureTime.Day) > 5)&& itineraryDictionary.ElementAt(i).Key.Airline=="American Airlines")
                    {
                        weight+=1000;
                        itineraryDictionary[itineraryDictionary.ElementAt(i).Key] = weight;
                    }
                }

            }
            return itineraryDictionary;
        }
    }
}
