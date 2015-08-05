using RollBaseAcess.Model;
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
        string _esUri = ConfigurationManager.AppSettings["ESUri"];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Employee empObject = ((Model.Session.Employee)Session["Response"]).ToServer();
                if (Page.IsPostBack == false)
                {
                    HttpClient client = new HttpClient();
                    var response = client.GetData<RemarkCount>(_esUri + "/remarkCount/" + empObject.Id.Trim() + " ", "application/json");
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
            HttpClient client = new HttpClient();
            var response = client.GetData<EmployeeResponse>(_esUri + "/employee/" + employeeId + "/" + pageNumber + "", "application/json");
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
            Employee empObject = ((Model.Session.Employee)Session["Response"]).ToServer();
            int pageNo = e.NewPageIndex;
            GridView1.PageIndex = pageNo;
            GridView1.DataSource = GetRemarks(empObject.Id, pageNo + 1);
            GridView1.DataBind();
        }

        

    }
}