using RollBaseAcess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollBaseAcess
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Employee empObject = ((Model.Session.Employee)Session["Response"]).ToServer();
                if (string.Equals(empObject.Title, "Hr") == true)
                {
                    Response.Redirect("HR/AddRemark.aspx");
                }
                Response.Redirect("Employee/Remarks.aspx");


            }

        }
    }
}