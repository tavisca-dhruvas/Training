using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OperatorOverloading.Dbl;

namespace OperatorOverloading.Dbl
{
    public class GetCurrencyConversionApi
    {

        private string AccessKey = ConfigurationManager.AppSettings["acessKey"];
        private string BaseUrl = ConfigurationManager.AppSettings["baseURL"];
        private string EndPoint = ConfigurationManager.AppSettings["endpoint"];


        public ApiClass SendRequest()
        {
            string uri = BaseUrl + EndPoint + "?access_key=" + AccessKey;
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            var response = sr.ReadToEnd().Trim();
            ApiClass apiObject = new ApiClass();
            apiObject = JsonParser(apiObject, response);
            return apiObject;
        }
        private ApiClass JsonParser(ApiClass apiObject, string response)
        {
            try
            {
                double rate;
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
                    keyValue[0] = keyValue[0].Remove(keyValue[0].Length - 1, 1);  //Removes the extra " with keyvalue
                    if ((double.TryParse(keyValue[1], out rate) == false))
                    {
                        throw new Exception(Resources.InvalidArgument);
                    }
                    apiObject.CurrencyRateDictionary.Add(keyValue[0], rate); // adds quote and keyvalue in Dictionary
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

