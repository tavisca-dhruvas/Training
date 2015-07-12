using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;
using System.Configuration;


namespace OperatorOverloading.Dbl
{
    public class CurrencyConverter : Iparse
    {
        public string SOURCE = ConfigurationManager.AppSettings["source"];
        public double GetConversion(string currency1, string currency2)
        {
            double rate;
            ConsumeApi consumeObject = new ConsumeApi();
            ApiClass apiObject = consumeObject.SendRequest();
            currency1 = currency1.ToUpper();
            currency2 = currency2.ToUpper();
            if (currency1.Equals(SOURCE))
            {
                return rate = apiObject.dictionaryObject[currency2];
            }
            else if (currency2.Equals(SOURCE))
            {
                return rate = (1/apiObject.dictionaryObject[currency1]);
            }
            else
                throw new Exception(Resources.InvalidCurrency);
        }
    }
}

