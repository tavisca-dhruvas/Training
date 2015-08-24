using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RollBasedAuthentication.Model
{
    public class HttpClient
    {
        private string _emsUri = ConfigurationManager.AppSettings["EMSUri"];
        public T GetData<T>(string url, string contentType = null)
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", contentType ?? "application/json");
            var response = client.DownloadString(url);
            return Serializer.Deserialize<T>(response);

        }

        public T2 UploadData<T1, T2>(string url, T1 data, string contentType = "application/json", string method = "POST")
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", contentType);
            var dataToBeUploaded = Serializer.Serialize<T1>(data);
            var response = client.UploadString(url, method, dataToBeUploaded);
            return Serializer.Deserialize<T2>(response);
        }

       
    }
}
