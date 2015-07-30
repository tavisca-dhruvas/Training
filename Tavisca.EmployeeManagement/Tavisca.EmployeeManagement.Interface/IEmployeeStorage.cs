using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeStorage
    {
        Employee Save(Employee employee);
        Remark SaveRemark(string employeeId,Remark remark);
        Employee Get(string employeeId);

        List<Employee> GetAll();
    }
}
