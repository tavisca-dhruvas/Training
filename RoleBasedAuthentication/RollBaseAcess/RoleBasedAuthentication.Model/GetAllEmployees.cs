using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RollBasedAuthentication.Model
{

    public class GetAllEmployee : Result
    {

        public List<Employee> AllEmployeeList
        {
            get;
            set;
        }
    }
}
