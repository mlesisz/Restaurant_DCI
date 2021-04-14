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
            Tuple<List<Product>, Order> tuple;
            Product product = new Product();
            product.Category = category;
            tuple = new Tuple<List<Product>, Order>(new BrowsingMenuContex(product, _db).FindProducts(), new Order());
            ViewBag.category = category;
            return View(tuple);
        }
        [HttpPost]
        public ActionResult ViewCategory(string category = "Dania główne")
        {
            Product product = new Product();
            product.Category = category;
            ViewBag.category = category;
            return PartialView("_Products", new BrowsingMenuContex(product, _db).FindProducts());
        }
        
        public ActionResult AddOrderItem(int productId)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.Product = _db.Products.FirstOrDefault(x => x.IdProduct == productId);
            orderItem.ProductId = orderItem.Product.IdProduct;
            return View(orderItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrderItem(OrderItem orderItem)
        {
            return RedirectToAction("Home");
        }
    }
}