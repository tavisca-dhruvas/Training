using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Data;
using System.Data.SqlClient;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {

        public Model.Employee Save(Model.Employee employee)
        {
            try
            {
                if (employee.Remarks == null)
                {
                    SqlConnection con = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Myprocedure", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter p2 = new SqlParameter("FirstName", employee.FirstName);
                    SqlParameter p3 = new SqlParameter("LastName", employee.LastName);
                    SqlParameter p4 = new SqlParameter("title", employee.Title);
                    SqlParameter p5 = new SqlParameter("Email", employee.Email);
                    SqlParameter p6 = new SqlParameter("phno", employee.Phone);
                    SqlParameter p7 = new SqlParameter("Doj", employee.JoiningDate.ToString());
                    SqlParameter p8 = new SqlParameter("Password","test123!@#");
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                    con.Open();
                    SqlCommand cmdRemark = new SqlCommand("AddRemark", con);
                    cmdRemark.CommandType = CommandType.StoredProcedure;

                    foreach (var empRemark in employee.Remarks)
                    {
                        cmdRemark.Parameters.Add(new SqlParameter("@EmpId", employee.Id));
                        cmdRemark.Parameters.Add(new SqlParameter("@Remark", empRemark.Text));
                        cmdRemark.Parameters.Add(new SqlParameter("@RemarkTime", empRemark.CreateTimeStamp));
                        cmdRemark.ExecuteNonQuery();

                    }

                    con.Close();
                }

                return employee;


            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Model.Employee Get(string employeeId)
        {
            try
            {
                Model.Employee emp = new Model.Employee();
                List<Model.Remark> tempRemark = new List<Model.Remark>();
                SqlConnection conEmp = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                conEmp.Open();
                SqlCommand cmd = new SqlCommand("GetbyId", conEmp);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", employeeId));

                SqlDataReader empReader = cmd.ExecuteReader();
                while (empReader.Read())
                {
                    emp.Id = empReader[0].ToString();
                    emp.FirstName = empReader[1].ToString();
                    emp.LastName = empReader[2].ToString();
                    emp.Title = empReader[3].ToString();
                    emp.Email = empReader[4].ToString();
                    emp.Phone = empReader[5].ToString();
                    emp.JoiningDate = DateTime.Parse(empReader[6].ToString());

                    Model.Remark remark = new Model.Remark();
                    remark.Text = empReader[10].ToString();
                    remark.CreateTimeStamp = Convert.ToDateTime(empReader[11]);
                    tempRemark.Add(remark);
                }
                emp.Remarks = tempRemark;
                conEmp.Close();
                return emp;
            }


            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }
        public Model.Remark SaveRemark(string employeeId, Model.Remark remark)
        {
           
              SqlConnection con = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                    con.Open();
                    SqlCommand cmdRemark = new SqlCommand("AddRemark", con);
                    cmdRemark.CommandType = CommandType.StoredProcedure;

                   
                  
                        cmdRemark.Parameters.Add(new SqlParameter("@EmpId", employeeId));
                        cmdRemark.Parameters.Add(new SqlParameter("@Remark", remark.Text));
                        cmdRemark.Parameters.Add(new SqlParameter("@RemarkTime", remark.CreateTimeStamp));
                        cmdRemark.ExecuteNonQuery();

                   

                    con.Close();

                    return remark;
        }

        public List<Model.Employee> GetAll()
        {
            List<Model.Employee> empList = new List<Model.Employee>();
           


            SqlConnection con = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAll ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader empReader = cmd.ExecuteReader();

            while (empReader.Read())
            {
                Model.Employee emp = new Model.Employee();
                emp.Id = empReader[0].ToString();
                emp.FirstName = empReader[1].ToString();
                emp.LastName = empReader[2].ToString();
                emp.Title = empReader[3].ToString();
                emp.Email = empReader[4].ToString();
                emp.Phone = empReader[5].ToString();
                emp.JoiningDate = DateTime.Parse(empReader[6].ToString());
                empList.Add(emp);
            }
            con.Close();
            return empList;

        }

        private string GetFileName(string employeeId)
        {
            return string.Format(@"{0}\{1}.emp", Configurations.StoragePath, employeeId);
        }
    }
}
