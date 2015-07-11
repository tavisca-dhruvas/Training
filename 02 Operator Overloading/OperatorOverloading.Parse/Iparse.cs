using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Parse
{
    public interface Iparse
    {
        double GetConversion(string currency1, string currency2);
    }
}
