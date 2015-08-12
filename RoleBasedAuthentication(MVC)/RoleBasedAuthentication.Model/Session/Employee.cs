using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollBasedAuthentication.Model.Session
{
    [Serializable]
    public class Employee
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Model.Employee ToServer()
        {
            return new Model.Employee
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Title = this.Title,
                Email = this.Email
            };
        }
    }
}