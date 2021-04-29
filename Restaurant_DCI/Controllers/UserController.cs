using Restaurant_DCI.Contex;
using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;
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
        private ISessionManager SessionManager { get; set; }

        public UserController()
        {
            SessionManager = new SessionManager();
        }

        public ActionResult Orders()
        {
            if (Session["idUser"] != null) {
                int id = (int)Session["idUser"];
                List<Order> orders = _db.Orders.Where(m => m.UserId.Equals(id)).ToList();
                return View(orders);
            }
            else
            {
                List<Order> orders = new List<Order>();
                return View(orders);
            }
            
        }
        public ActionResult Home(string category = "Dania główne")
        {
            Product product = new Product
            {
                Category = category
            };
            ViewBag.category = category;
            (IEnumerable<Product>,(IEnumerable<CartItem>,decimal)) tuple;
            tuple.Item1 = new BrowsingMenuContex(product, _db).FindProducts();
            tuple.Item2.Item1 = new PlaceAnOrderContex(null, SessionManager).GetCarts();
            tuple.Item2.Item2 = 0;
            foreach (var item in tuple.Item2.Item1)
            {
                tuple.Item2.Item2 += item.TotalPrice;
            }
            return View(tuple);
        }
        [HttpPost]
        public ActionResult ViewCategory(string category = "Dania główne")
        {
            Product product = new Product
            {
                Category = category
            };
            ViewBag.category = category;
            return PartialView("_Products", new BrowsingMenuContex(product, _db).FindProducts());
        }
    }
}