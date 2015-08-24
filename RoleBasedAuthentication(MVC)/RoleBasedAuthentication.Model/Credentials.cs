using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

 namespace RollBasedAuthentication.Model
{

    public class Credentials
    {
        private string _emsUri = ConfigurationManager.AppSettings["EMSUri"];

        public string EmailId { get; set; }


        public string Password { get; set; }

        public EmployeeResponse Authenticate(Credentials credentials)
        {
            HttpClient client = new HttpClient();
            var empResponse = client.UploadData<Credentials, EmployeeResponse>(_emsUri + "/login", credentials);
            return empResponse;
        }

    }
}
