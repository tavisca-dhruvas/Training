﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC.Rules
{
    class ImpressionCampaignNegotiation : IGetValue
    {
        public Dictionary<Itinerary, int> IWeightGenerator(Dictionary<Itinerary, int> itineraryDictionary, int weight)
        {
            
             for (int i = 0; i < itineraryDictionary.Count(); i++)
            
            {
                if (itineraryDictionary.ElementAt(i).Key.Airline == "American Airline")  //Airline of the month
                {
                    weight += 1000;
                    itineraryDictionary[itineraryDictionary.ElementAt(i).Key] = weight;
                }
            }
            return itineraryDictionary;
        }
    }
}
