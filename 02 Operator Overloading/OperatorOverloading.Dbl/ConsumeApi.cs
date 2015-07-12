using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OperatorOverloading.Dbl;

namespace OperatorOverloading.Dbl
{
    public class ConsumeApi
    {

        public string ACCESS_KEY = ConfigurationManager.AppSettings["acessKey"];
        public string BASE_URL = ConfigurationManager.AppSettings["baseURL"];
        public string ENDPOINT = ConfigurationManager.AppSettings["endpoint"];
        

        public ApiClass SendRequest()
        {
            string uri = BASE_URL + ENDPOINT + "?access_key=" + ACCESS_KEY;
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            var response = sr.ReadToEnd().Trim();
            CurrencyConverter currencyConverterObject = new CurrencyConverter();
            ApiClass apiObject = new ApiClass();
            apiObject =JasonParser(apiObject, response);
            return apiObject;
        }
        public ApiClass JasonParser(ApiClass apiObject, string response)
        {
            try
            {
                string[] blocks = response.Split('{', '}');
                //Splits the String in Properties and Data
                string[] sourceFinder = blocks[1].Split(',');   //Splits Source and Quote
                string[] keyValue;

                string[] currencyRate = blocks[2].Split(',');   //splits currency rates
                foreach (string individualRates in currencyRate)
                {

                    keyValue = individualRates.Split(':');
                    keyValue[0] = keyValue[0].Trim();
                    keyValue[0] = keyValue[0].Remove(0, 4);
                    keyValue[0] = keyValue[0].Remove(keyValue[0].Length - 1, 1); //Removes the extra " with keyvalue
                    apiObject.dictionaryObject.Add(keyValue[0], double.Parse(keyValue[1])); // adds quote and keyvalue in Dictionary
                }
            }
            catch (Exception)
            {
                throw new System.Exception(Resources.InvalidApiFormat);
            }
            return apiObject;
        }
    }
}

