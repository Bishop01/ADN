using Assignment_03.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Assignment_03.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new ShoppingEntities();
            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Add_to_Cart(int id, string name, int price)
        {
            Product product = new Product() { id = id, name = name, price = price };
            List<Product> products;

            if (!string.IsNullOrEmpty(Session["cart"] as string))
            {
                string j = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<Product>>(j);
            }
            else
            {
                products = new List<Product>();
            }

            products.Add(product);

            string json = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json;
            Session["cartCount"] = products.Count();

            return RedirectToAction("Index");
        }

        public ActionResult Remove_from_Cart(int id)
        {
            List<Product> products;

            string j = Session["cart"].ToString();
            products = new JavaScriptSerializer().Deserialize<List<Product>>(j);

            foreach (Product product in products)
            {
                if(id == product.id)
                {
                    products.Remove(product);
                    break;
                }
            }

            string json = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json;
            Session["cartCount"] = products.Count();

            return RedirectToAction("Checkout");
        }

        public ActionResult Checkout()
        {
            List<Product> products = null;
            if (!string.IsNullOrEmpty(Session["cart"] as string))
            {
                ViewBag.error = "";
                string json = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                return View(products);
            }

            ViewBag.error = "No product is in the cart!";
            return View(products);
        }
    }
}