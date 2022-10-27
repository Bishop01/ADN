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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var employees = EmployeeDB.All();
            var requests = RequestDB.All();

            List<EmployeeModel> availableEmployees = new List<EmployeeModel>();

            foreach (var employee in employees)
            {
                foreach(var request in requests)
                {
                    if(request.employee != null)
                    {
                        if (employee.id == request.employee.id)
                        {
                            if (request.status == "incomplete")
                            {
                                continue;
                            }
                        }
                    }
                    if (!availableEmployees.Contains(employee) && employee.role != 1)
                    {
                        availableEmployees.Add(employee);
                    }
                }
            }

            ViewBag.Employees = availableEmployees;
            return View(requests);
        }
    }
}