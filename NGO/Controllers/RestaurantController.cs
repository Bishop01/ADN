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
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(RestaurantDB.All());
        }

        public ActionResult Dashboard(int id)
        {
            ViewBag.restaurantId = id;
            Session["restaurantId"] = id;
            return View(RequestDB.All(id));
        }
        [HttpPost]
        new public ActionResult Request(RequestModel request)
        {
            if (RequestDB.Add(request) == 1)
                return RedirectToAction("Dashboard", new { id = (int)Session["restaurantId"]});
            else
                return RedirectToAction("Index");
        }
    }
}