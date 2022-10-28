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

            List<EmployeeModel> availableEmployees = new List<EmployeeModel>(employees);

            foreach (var employee in employees)
            {
                if(employee.role == 0)
                {
                    foreach (var request in requests)
                    {
                        if(request.employeeId == employee.id)
                        {
                            if(request.status == "incomplete")
                            {
                                availableEmployees.Remove(employee);
                            }
                        }
                    }
                }
                else
                {
                    availableEmployees.Remove(employee);
                }
                //foreach(var request in requests)
                //{
                //    if(request.employee != null)
                //    {
                //        if (employee.id == request.employee.id)
                //        {
                //            if (request.status == "incomplete")
                //            {
                //                continue;
                //            }
                //        }
                //    }
                //    if (!availableEmployees.Contains(employee) && employee.role != 1)
                //    {
                //        availableEmployees.Add(employee);
                //    }
                //}
            }

            ViewBag.Employees = availableEmployees;
            return View(requests);
        }

        [HttpPost]
        public ActionResult AssignEmployee(RequestModel request)
        {
            if (RequestDB.Update(request) == 1)
                return RedirectToAction("Index");

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Completed()
        {
            return View(RequestDB.All());
        }

        public ActionResult CompleteRequest(int id)
        {
            if (RequestDB.Update(id, "completed") == 1)
                return RedirectToAction("Completed");

            return RedirectToAction("Index");
        }
        public ActionResult DeleteRequest(int id)
        {
            RequestDB.Update(id, "deleted");
            return RedirectToAction("Index");
        }
    }
}