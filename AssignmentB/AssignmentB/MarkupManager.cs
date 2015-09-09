using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB
{
    public class MarkupManager
    {
        public List<Itinerary> CalculateMarkup(Itinerary published, List<Itinerary> discounted)
        {
           MarkupDesigner markupDesigner= new MarkupDesigner();

           var markedList = markupDesigner.GetMarkup(published, discounted);
            return markedList;
        }
    }
}
