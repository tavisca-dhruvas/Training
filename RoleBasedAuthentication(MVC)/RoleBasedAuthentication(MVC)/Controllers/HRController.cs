using RoleBasedAuthentication_MVC_.Models;
using RollBasedAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace RoleBasedAuthentication_MVC_.Controllers
{
    public class HRController : Controller
    {

        public ActionResult AddRemarks(Remark remark)
        {
            if (HttpContext.User.IsInRole("Hr") == false)
            {
                return RedirectToAction("Login", "Account");
            }
            Dictionary<string, string> employeeDictionary = new Dictionary<string, string>();
            employeeDictionary = new Remark().ShowEmployee();
            List<SelectListItem> employeeDetails = new List<SelectListItem>();
            foreach (var dictionary in employeeDictionary)
            {
                employeeDetails.Add(new SelectListItem { Text = dictionary.Key, Value = dictionary.Value });

            }
            ViewData["Employee"] = employeeDetails;
            if (Request["SelectedIndex"]!=null)
            {
                string Id = Request["SelectedIndex"].ToString();
                remark.CreateTimeStamp = DateTime.UtcNow;
                var result = new Remark().Add(Convert.ToInt32(Id), remark);
                if (result.StatusCode != "200")
                {
                    ViewData["Label"] = "Error occurred while adding remark!!";
                    return View("AddRemark");
                }

                ViewData["Label"] = "Success!!";
                ModelState.Clear();
                return View("AddRemarks");
            }
            ViewData["Label"] = "";
            return View();
        }




        public ActionResult AddEmployee(Employee employee)
        {
           if (HttpContext.User.IsInRole("Hr") == false)
            {
               return RedirectToAction("Login", "Account");
            }

            if (employee.Email!=null)
            {
                employee.JoiningDate = DateTime.UtcNow;
                try
                {
                    var result = employee.CreateEmployee(employee);
                    ViewData["Status"] = "Success";
                    return View("AddEmployee");
                }
                catch (Exception)
                {
                    ViewData["Status"] = "Failed to add the employee record";
                    return View("AddEmployee");
                }
            }
            ViewData["Status"] = "";
            return View();
        }
       

    }
}
