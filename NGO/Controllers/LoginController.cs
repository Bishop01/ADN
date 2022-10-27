using NGO.DB;
using NGO.DBContext;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(EmployeeModel employeeModel)
        {
            Employee employee = AuthenticationDB.VerifyLogin(employeeModel);
            if(employee != null)
            {
                Session["role"] = employee.role;
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index");
        }
    }
}