
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RollBasedAuthentication.Model
{

    public class EmployeeResponse : Result
    {

        public Employee Employee
        {
            get;
            set;
        }
    }
}
