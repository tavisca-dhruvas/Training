using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RollBasedAuthentication.Model
{
    [DataContract]
    public class Employee
    {
        [Required]
        [DataMember]
        public string Id { get; set; }
        [Required]
        [DataMember]
        public string Title { get; set; }
        [Required]
        [DataMember]
        public string FirstName { get; set; }
        [Required]
        [DataMember]
        public string LastName { get; set; }
        [Required]
        [DataMember]
        public string Email { get; set; }
        [Required]
        [DataMember]
        public string Phone { get; set; }
        
        [DataMember]
        public DateTime JoiningDate { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<Remark> Remarks { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.FirstName))
                throw new Exception("FirstName cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(this.Email))
                throw new Exception("Email cannot be null or empty.");

        }

        public void PasswordValidate()
        {
            if (string.IsNullOrWhiteSpace(this.Password))
                throw new Exception("password cannot be null or empty.");
        }

        public Session.Employee ToSession()
        {
            return new Session.Employee
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Title = this.Title,
                Email = this.Email
            };
        }
        public Status CreateEmployee(Employee employee)
        {

            string EmployeeManagementServiceUrl = ConfigurationManager.AppSettings["EMSUri"];
            var client = new HttpClient();
            var createdEmployee = client.UploadData<Employee, EmployeeResponse>(EmployeeManagementServiceUrl + "/employee", employee);
            if (createdEmployee.Status.StatusCode.Equals("200"))
            {
                return (createdEmployee.Status);
            }
            else
                return null;
        }
    }
}
