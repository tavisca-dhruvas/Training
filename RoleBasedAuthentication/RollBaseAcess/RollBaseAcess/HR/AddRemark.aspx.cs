using RollBaseAcess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollBaseAcess.HR
{
    public partial class AddRemark : System.Web.UI.Page
    {


        string _emsUri = ConfigurationManager.AppSettings["EMSUri"];
        string _esUri = ConfigurationManager.AppSettings["ESUri"];
        public Dictionary<string, string> empRecord = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Page.IsPostBack == false)
                {
                    HttpClient client = new HttpClient();
                    var empResponse = client.GetData<GetAllEmployee>(_esUri + "/employee");
                    if (empResponse.Status.StatusCode != "200")
                    {

                        return;
                    }
                    foreach (var employeeRecord in empResponse.AllEmployeeList.OrderBy(employee => employee.FirstName))
                    {
                        empRecord.Add(employeeRecord.FirstName + " " + employeeRecord.LastName, employeeRecord.Id);
                    }
                    DropDownList1.DataTextField = "Key";
                    DropDownList1.DataValueField = "Value";
                    DropDownList1.DataSource = empRecord;
                    DropDownList1.DataBind();

                }
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Remark remark = new Remark();
                int employeeId = Convert.ToInt32(DropDownList1.SelectedValue);
                remark.Text = TextBox1.Text;
                remark.CreateTimeStamp = DateTime.UtcNow;
                HttpClient client = new HttpClient();
                var empRespone = client.UploadData<Remark, Employee>(_emsUri + "/employee/" + employeeId + "/remark", remark);
                Label2.Text = "Success!!";
                TextBox1.Text = "";
                DropDownList1.SelectedIndex = -1;


            }
            catch (Exception)
            {

            }

        }
    }
}