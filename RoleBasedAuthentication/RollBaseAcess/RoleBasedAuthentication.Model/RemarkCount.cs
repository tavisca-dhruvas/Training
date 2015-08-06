using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Configuration;

namespace RollBasedAuthentication.Model
{

    public class RemarkCount : Result
    {
        private string _esUri = ConfigurationManager.AppSettings["ESUri"];
        public string totalRemark
        {
            get;
            set;
        }
        public RemarkCount CountRemark(Employee empObject)
        {
            HttpClient client = new HttpClient();
            var response = client.GetData<RemarkCount>(_esUri + "/remarkCount/" + empObject.Id.Trim() + " ", "application/json");
            return response;
        }
    }
}
