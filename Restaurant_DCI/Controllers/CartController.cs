using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Controllers
{
    public class CartController : Controller
    {
        private readonly DB_Entities _db = new DB_Entities();
        private ISessionManager SessionManager { get; set; }
        public CartController()
        {
            SessionManager = new SessionManager();
        }

        public ActionResult AddToCart(int productId)
        {
            Product product = _db.Products.FirstOrDefault(p => p.IdProduct== productId);
            CartItem cartItem = new CartItem
            {
                Product = product,
                TotalPrice = product.Price
            };
            CartItem pom = new PlaceAnOrderContex(cartItem, SessionManager).FindCartItemInSession();
            if (pom != null)
            {
                cartItem = pom;
            }
            return View(cartItem);
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                cartItem.Product = _db.Products.FirstOrDefault(p => p.IdProduct == cartItem.Product.IdProduct);
                new PlaceAnOrderContex(cartItem, SessionManager).AddCartItemToSession();
                return RedirectToAction("Home","User",new {category = cartItem.Product.Category });
            }
            else
            {
                cartItem.Product = _db.Products.FirstOrDefault(p => p.IdProduct == cartItem.Product.IdProduct);
                return View(cartItem);
            }

        }
    }
}