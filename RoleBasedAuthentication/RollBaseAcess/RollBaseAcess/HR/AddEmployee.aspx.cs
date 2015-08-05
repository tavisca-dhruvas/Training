using RollBaseAcess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RollBaseAcess.HR
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        string _emsUri = ConfigurationManager.AppSettings["EMSUri"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Employee employee = new Employee();
            employee.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBox1.Text);
            employee.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBox2.Text);
            employee.Title = DropDownList1.SelectedValue;
            employee.Phone = TextBox4.Text;
            employee.Email = TextBox5.Text;
            employee.JoiningDate = DateTime.UtcNow;
            HttpClient client = new HttpClient();
            var empRespone = client.UploadData<Employee, Employee>(_emsUri+"/employee", employee);
            if (empRespone == null)
            {
                Label6.Text = "OOPs!! There occure some error.";
                return;
            }
            Label6.Text = "OK!! Success";
            
           
        }
    }
}