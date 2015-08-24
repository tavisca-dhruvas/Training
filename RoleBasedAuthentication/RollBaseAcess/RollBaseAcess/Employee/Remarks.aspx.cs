using RollBasedAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RollBaseAcess
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Employee empObject = ((RollBasedAuthentication.Model.Session.Employee)Session["Response"]).ToServer();
                if (Page.IsPostBack == false)
                {
                    RemarkCount remarkObject = new RemarkCount();
                    var response = remarkObject.CountRemark(empObject);
                    GridView1.VirtualItemCount = Convert.ToInt32(response.totalRemark);
                    GridView1.DataSource = GetRemarks(empObject.Id.Trim(), 1);
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {
                FormsAuthentication.RedirectToLoginPage();

            }

        }

        public List<Remark> GetRemarks(string employeeId, int pageNumber)
        {
            Remark remark = new Remark();
            var response = remark.GetRemark(employeeId,pageNumber);
            List<Remark> remarklList = new List<Remark>();
            remarklList = response.Employee.Remarks;

            return remarklList;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Employee empObject = ((RollBasedAuthentication.Model.Session.Employee)Session["Response"]).ToServer();
            int pageNo = e.NewPageIndex;
            GridView1.PageIndex = pageNo;
            GridView1.DataSource = GetRemarks(empObject.Id, pageNo + 1);
            GridView1.DataBind();
        }

        

    }
}