using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;
using System.Configuration;


namespace OperatorOverloading.Dbl
{
    public class CurrencyConverter : IParse
    {
        private string Source = ConfigurationManager.AppSettings["source"];
        public double GetConversion(string currency1, string currency2)
        {
            double rate;
            GetCurrencyConversionApi conversionApiObject = new GetCurrencyConversionApi();
            ApiClass apiObject = conversionApiObject.SendRequest();
            currency1 = currency1.ToUpper();
            currency2 = currency2.ToUpper();
            if (currency1.Equals(Source))
            {
                return rate = apiObject.CurrencyRateDictionary[currency2];
            }
            else if (currency2.Equals(Source))
            {
                return rate = (1 / apiObject.CurrencyRateDictionary[currency1]);
            }
            else
                throw new Exception(Resources.InvalidCurrency);
        }
    }
}

