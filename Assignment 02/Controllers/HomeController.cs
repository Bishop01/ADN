using Assignment_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_02.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            if(ModelState.IsValid)
            {
                TempData["msg"] = "Validation Successful";
                student = null;
            }
            return View(student);
        }
    }
}