using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Tavisca.WCF.DAL
{
    public class FileSystem
    {
        public void SaveEmployee(string jsonString, string id)
        {
            try
            {
                if (File.Exists(@"D:\EmployeeDetails.Txt"))
                    //throw new Exception("File doenot exists");
               // else
                    File.WriteAllText(@"D:\EmployeeDetails\" + id + ".Txt", jsonString);
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, "Policy");
                if (rethrow)
                {
                    throw;
                }
            }
        }
        public string RetrieveById(String id)
        {
                var jsonString = File.ReadAllText(@"D:\EmployeeDetails\" + id);
                return jsonString;
            
        }

        public List<string> RetrieveAllIds()
        {
          
                // var allId = File.ReadAllText(@"D:\EmployeeIDs\AllEmpID.Txt");
                DirectoryInfo dir = new DirectoryInfo(@"D:\EmployeeDetails");
                var files = dir.GetFiles("*.txt");
                List<string> empId = new List<string>();


                foreach (var file in files)
                {
                    empId.Add(file.Name);
                }
                return empId;
        }
    
    }
}
