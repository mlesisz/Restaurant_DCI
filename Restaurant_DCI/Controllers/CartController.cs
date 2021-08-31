using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_DCI.Models;
using Restaurant_DCI.RoleMethods;
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

        public ActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                bool saved;

                saved = new PlaceAnOrderContex(order,SessionManager,_db).SaveOrder();
                if (saved)
                {
                    return RedirectToAction("Home","User");
                }
                else
                {
                    ViewBag.error = "Coś poszło nie tak.";
                    return View();
                }
            }
            return View();
        }

        public ActionResult RemoveFromCart(int productId = 1)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductId == productId);
            CartItem cartItem = new CartItem {
                Product = product
            };
            new PlaceAnOrderContex(cartItem, SessionManager).RemoveCartItemFromSession();
            return RedirectToAction("Home","User");
        }

        public ActionResult AddToCart(int productId=1)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductId== productId);
            CartItem cartItem = new CartItem
            {
                Product = product,
                TotalPrice = product.Price
            };
            CartItem pom = new PlaceAnOrderContex(cartItem, SessionManager).FindCartItemInSession();
            if (pom != null)
            {
                ViewBag.InCart = true;
                cartItem = pom;
            }
            else
            {
                ViewBag.InCart = false;
            }
            return View(cartItem);
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                if (cartItem.Quantity == 0)
                {
                    new PlaceAnOrderContex(cartItem, SessionManager).RemoveCartItemFromSession();
                }
                else
                {
                    cartItem.Product = _db.Products.FirstOrDefault(p => p.ProductId == cartItem.Product.ProductId);
                    new PlaceAnOrderContex(cartItem, SessionManager).AddCartItemToSession();
                }
                return RedirectToAction("Home","User",new {category = cartItem.Product.Category });
            }
            else
            {
                cartItem.Product = _db.Products.FirstOrDefault(p => p.ProductId == cartItem.Product.ProductId);
                return View(cartItem);
            }

        }
    }
}