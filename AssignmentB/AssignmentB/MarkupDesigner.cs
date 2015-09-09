using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB
{
   public  class MarkupDesigner
    {
       public List<Itinerary> GetMarkup(Itinerary published, List<Itinerary> discounted)
       {
           MarkupCalculator markupCalculator = new MarkupCalculator();

           foreach (Itinerary itineraryObj in discounted)
           {
               var markup = markupCalculator.Getmarkup(published,itineraryObj);
               itineraryObj.MarkupInUSD = markup;
           }
           return discounted;
       }
    }
}
