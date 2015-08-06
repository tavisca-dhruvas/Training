using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RollBasedAuthentication.Model;
using System.Configuration;



namespace RollBaseAcess
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Employee empObject = ((RollBasedAuthentication.Model.Session.Employee)Session["Response"]).ToServer();
                if (empObject == null)
                {
                    Response.Redirect("Login.aspx");
                }
                TextBox1.Text = empObject.Email;
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ChangePasssword changePassword = new ChangePasssword();
            changePassword.EmailId = TextBox1.Text;
            changePassword.OldPassword = TextBox2.Text;
            changePassword.NewPassword = TextBox4.Text;

           var empResponse= changePassword.UpdatePassword(changePassword);
           
            if (empResponse.StatusCode!="200")
            {
                Label5.Text = "Failure!!";
                return;
            }
            Label5.Text="Success!!";
        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Remarks.aspx");
        }

        
    }
}