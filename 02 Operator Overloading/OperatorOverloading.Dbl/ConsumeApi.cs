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

        public ApiClass sendRequest()
        {
            string URI = BASE_URL + ENDPOINT + "?access_key=" + ACCESS_KEY;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            var response = sr.ReadToEnd().Trim();
            CurrencyConverter CurrencyConverterObject = new CurrencyConverter();
            ApiClass apiObject = new ApiClass();
            apiObject =jasonParser(apiObject, response);
            return apiObject;
        }
        public ApiClass jasonParser(ApiClass apiObject, string response)
        {
            string[] blocks = response.Split('{', '}');
            string[] sourceFinder = blocks[1].Split(',');
            string[] keyValue;

                        string[] currencyRate = blocks[2].Split(',');
                        foreach (string individualRates in currencyRate)
                        {
                            
                            keyValue = individualRates.Split(':');
                            keyValue[0] = keyValue[0].Trim();
                            keyValue[0] = keyValue[0].Remove(0, 4);
                            keyValue[0] = keyValue[0].Remove(keyValue[0].Length - 1, 1);
                            apiObject.DictionaryObject.Add(keyValue[0], double.Parse(keyValue[1]));
                            
                        }
            return apiObject;
        }
    }
}

