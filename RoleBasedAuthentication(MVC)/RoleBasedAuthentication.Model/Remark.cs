
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;



namespace RollBasedAuthentication.Model
{
    [DataContract]
    public class Remark
    {

        [Required]
        [DataMember]
        public string Text { get; set; }

        [Required]
        [DataMember]
        public DateTime CreateTimeStamp { get; set; }
        
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Text))
                throw new Exception("Text cannot be null or empty.");
        }

        public Dictionary<string, string> ShowEmployee()
        {
            
            string esUri = ConfigurationManager.AppSettings["ESUri"];
            Dictionary<string, string> empRecord = new Dictionary<string, string>();
            var client = new HttpClient();
            var empResponse = client.GetData<GetAllEmployee>(esUri + "/employee");
            if (empResponse == null)
            {
                return null;
            }
            foreach (var employeeRecord in empResponse.AllEmployeeList.OrderBy(employee => employee.FirstName))
            {
                empRecord.Add(employeeRecord.FirstName + " " + employeeRecord.LastName, employeeRecord.Id);
            }

            return empRecord;
        }

        public Status Add(int employeeId, Remark remark)
        {
            
        string emsUri = ConfigurationManager.AppSettings["EMSUri"];
       
        
            HttpClient client = new HttpClient();
            var empRespone = client.UploadData<Remark, RemarkResponse>(emsUri + "/employee/" + employeeId + "/remark", remark);

            return empRespone.Status;
        }

        public EmployeeResponse GetRemark(string employeeId, int pageNumber)
        {
            
        
       
         string esUri = ConfigurationManager.AppSettings["ESUri"];
            HttpClient client = new HttpClient();
            var response = client.GetData<EmployeeResponse>(esUri + "/employee/" + employeeId + "/" + pageNumber + "", "application/json");
            return response;
        }
    }
}
