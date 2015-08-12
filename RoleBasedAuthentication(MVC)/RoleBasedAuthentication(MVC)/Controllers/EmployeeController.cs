using RollBasedAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthentication_MVC_.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("Hr") == true)
                return RedirectToAction("AddRemarks", "HR");
            else
                return RedirectToAction("ViewRemarks", "Employee");
        }
        //
        // GET: /Employee/

        [AllowAnonymous]
        public ActionResult ViewRemarks(int page = 1)
        {
            if (HttpContext.User.IsInRole("Hr")==true)
            {
                return RedirectToAction("Login", "Account");
            }
            int pageSize = 2;
            int totalPages = 0;
            int totalRemarks = 0;
            //trial for id=1:
            Remark remarkObject = new Remark();
            var remarkListResponse = remarkObject.GetRemark(User.Identity.Name, page);
            RemarkCount remarkCountObject = new RemarkCount();
            var remarksNumber = remarkCountObject.CountRemark("1");
            totalRemarks = Convert.ToInt32(remarksNumber.totalRemark);
            totalPages = (totalRemarks / pageSize) + ((totalRemarks % pageSize) > 0 ? 1 : 0);
            List<Remark> remarks = remarkListResponse.Employee.Remarks.ToList();

            ViewBag.TotalRecords = totalRemarks;
            ViewBag.PageSize = 2;
            return View(remarks);
        }

       

    }

}
