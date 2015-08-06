using RollBasedAuthentication.Model;
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


       
        public Dictionary<string, string> empRecord = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Remark remark = new Remark();
                var empRecord = remark.ShowEmployee();

                if (Page.IsPostBack == false)
                {
        
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

               var remarkResponse = remark.Add(employeeId, remark);
               if (remarkResponse.StatusCode != "200")
               {
                   Label2.Text = "Remark Not Added";
               }

                Label2.Text = "Successfull!!";
                TextBox1.Text = "";
                DropDownList1.SelectedIndex = -1;


            }
            catch (Exception)
            {

            }

        }
    }
}