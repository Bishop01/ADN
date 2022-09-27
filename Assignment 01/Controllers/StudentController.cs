using Assignment_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_01.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            string id = "20-42560-1";
            string name = "Al-Monaem Khan";
            Education education = new Education(5.00, 5.00, 3.99);
            string contact = "0123456789101";
            double cgpa = 3.99;

            ViewBag.Student = new Student(id, name, education, cgpa, contact);

            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }
    }
}