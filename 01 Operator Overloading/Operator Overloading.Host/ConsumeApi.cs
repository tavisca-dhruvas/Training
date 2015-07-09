using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OperatorOverloading.Host
{
    public class ConsumeApi
    {
        public string ACCESS_KEY = ConfigurationManager.AppSettings["acessKey"];
        public string BASE_URL = ConfigurationManager.AppSettings["baseURL"];
        public string ENDPOINT = ConfigurationManager.AppSettings["endpoint"];

        public void sendRequest()
        {
            string URI = BASE_URL + ENDPOINT + "?access_key=" + ACCESS_KEY;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            var response = sr.ReadToEnd().Trim();

        }

    }
}
