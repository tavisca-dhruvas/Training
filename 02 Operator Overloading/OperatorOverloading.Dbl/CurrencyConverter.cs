using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;


namespace OperatorOverloading.Dbl
{
    public class CurrencyConverter : Iparse
    {
        public double GetConversion(string currency1, string currency2)
        {
            double rate;
            ConsumeApi ConsumeObject = new ConsumeApi();
            ApiClass apiObject = ConsumeObject.sendRequest();
            currency1 = currency1.ToUpper();
            if (currency1.Equals("USD"))
            {
                return rate = apiObject.DictionaryObject["INR"];
            }
            else if (currency1.Equals("INR"))
            {
                return rate = (1/apiObject.DictionaryObject["INR"]);
            }
            else
                throw new Exception(Resources.InvalidCurrency);
        }
    }
}

