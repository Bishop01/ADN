using Assignment_03.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_03.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return RedirectToAction("Manage");
        }

        [HttpGet]
        public ActionResult Manage()
        {
            var db = new ShoppingEntities();
            var products = db.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult Manage(Product product)
        {
            var db = new ShoppingEntities();
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Delete(int id)
        {
            var db = new ShoppingEntities();
            var product = (from p in db.Products
                           where p.id == id
                           select p).SingleOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        public ActionResult Edit(int id)
        {
            var db = new ShoppingEntities();
            var product = (from p in db.Products
                           where p.id == id
                           select p).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var db = new ShoppingEntities();

            if (ModelState.IsValid)
            {
                var old_product = db.Products.Find(product.id);
                old_product.name = product.name;
                old_product.price = product.price;
                db.Entry(old_product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            return View(product);
        }
    }
}