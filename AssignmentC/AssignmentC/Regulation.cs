using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentC.Rules;

namespace AssignmentC
{
    public class Regulation
    {
        AmericanAirlineNegotiation americanAirlineNegotiation = new AmericanAirlineNegotiation();
        SouthWestAirlineNegotiation southWestAirlineNegotiation = new SouthWestAirlineNegotiation();
        SpiritAirlineNegotiation spiritAirlineNegotiation = new SpiritAirlineNegotiation();
        ImpressionCampaignNegotiation impressionCampaignNegotiation = new ImpressionCampaignNegotiation();

        int weight = 0;

        public Dictionary<Itinerary, int> ApplyRules(List<Itinerary> discounted)
        {
            bool flag = true;
            Dictionary<Itinerary, int> itineraryDictionary = new Dictionary<Itinerary, int>();

            foreach (Itinerary obj in discounted)
            {
                itineraryDictionary.Add(obj, 0);
            }
            itineraryDictionary = americanAirlineNegotiation.IWeightGenerator(itineraryDictionary, weight);
            itineraryDictionary = southWestAirlineNegotiation.IWeightGenerator(itineraryDictionary, weight);
            itineraryDictionary = spiritAirlineNegotiation.IWeightGenerator(itineraryDictionary, weight);

            foreach (KeyValuePair<Itinerary, int> entry in itineraryDictionary)
            {
                if (entry.Value.Equals(0))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }

            }
            if (flag == true)
                itineraryDictionary = impressionCampaignNegotiation.IWeightGenerator(itineraryDictionary, weight);

            return itineraryDictionary;
        }
    }
}
