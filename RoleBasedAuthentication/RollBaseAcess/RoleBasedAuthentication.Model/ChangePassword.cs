using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RollBasedAuthentication.Model
{
    public class ChangePasssword
    {
        private string _emsUri = ConfigurationManager.AppSettings["EMSUri"];

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string EmailId { get; set; }

        public Status UpdatePassword(ChangePasssword changePassword)
        {
            HttpClient client = new HttpClient();
            var empResponse = client.UploadData<ChangePasssword, Result>(_emsUri + "/update", changePassword);
            return empResponse.Status;
        }
    }
}