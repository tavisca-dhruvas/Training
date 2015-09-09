using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC
{
    interface IGetValue
    {
         Dictionary<Itinerary, int> IWeightGenerator(Dictionary<Itinerary,int> itineraryDictionary,int weight);
    }
}
