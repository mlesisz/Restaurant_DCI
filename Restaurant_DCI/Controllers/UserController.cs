using Restaurant_DCI.Contex;
using Restaurant_DCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_DCI.Controllers
{
    public class UserController : Controller
    {
        private readonly DB_Entities _db = new DB_Entities();
        public ActionResult Home(string category = "Dania główne")
        {
            Product product = new Product();
            product.Category = category;
            ViewBag.category = category;
            return View(new BrowsingMenuContex(product, _db).FindProducts());
        }
        [HttpPost]
        public ActionResult ViewCategory(string category = "Dania główne")
        {
            Product product = new Product();
            product.Category = category;
            ViewBag.category = category;
            return PartialView("_Products", new BrowsingMenuContex(product, _db).FindProducts());
        }
    }
}