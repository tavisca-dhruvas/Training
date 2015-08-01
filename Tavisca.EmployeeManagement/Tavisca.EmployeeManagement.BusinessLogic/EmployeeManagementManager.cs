using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManagementManager : IEmployeeManagementManager
    {
        public EmployeeManagementManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Create(Employee employee)
        {
            employee.Validate();
           
            return _storage.Save(employee);
        }

        public Remark AddRemark(string employeeId, Remark remark)
        {
            remark.Validate();
          
            remark.CreateTimeStamp = DateTime.UtcNow;
            
            _storage.SaveRemark(employeeId,remark);
            return remark;
        }

        public Employee  UpdatePassword(string employeeId, Employee employee)
        {
            employee.PasswordValidate();
            _storage.UpdatePassword(employeeId, employee);
            return employee;
 
        }
        public Employee Authenticate(string emailId, string password)
        {
          var employee = _storage.Authenticate(emailId,password);
           if (employee == null)
           {
               return null;
           }
           return employee;
       }
    }
}
