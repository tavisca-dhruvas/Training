using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
namespace Tavisca.WCF.DAL
{
    public class FileSystem
    {
        public void SaveEmployee(string jsonString, string id)
        {
            if (File.Exists(@"D:\EmployeeID\ID.Txt"))
            {
                File.AppendAllText(@"D:\EmployeeID\ID.Txt", id + Environment.NewLine);
            }
            else
            {

                File.WriteAllText(@"D:\EmployeeID\ID.Txt", id + Environment.NewLine);
            }

            File.WriteAllText(@"D:\EmployeeDetails\" + id + ".Txt", jsonString);


        }
        public string RetrieveById(String id)
        {
            var jsonString = File.ReadAllText(@"D:\EmployeeDetails\" + id );
            return jsonString;
        }

        public List<string> RetrieveAllIds()
       {
          
          // var allId = File.ReadAllText(@"D:\EmployeeIDs\AllEmpID.Txt");
           DirectoryInfo dir = new DirectoryInfo(@"D:\EmployeeDetails");
           var files = dir.GetFiles("*.txt");
            List<string> empId=new List<string>();
            
            
           foreach (var file in files)
           {
            empId.Add(file.Name);   
           }
           return empId;
          
       }
    }
}
