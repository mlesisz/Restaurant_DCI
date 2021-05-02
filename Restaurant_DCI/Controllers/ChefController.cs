using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_DCI.Models;
using Restaurant_DCI.Contex;
namespace Restaurant_DCI.Controllers
{
    public class ChefController : Controller
    {
        private readonly DB_Entities _db = new DB_Entities();
        public ActionResult AddOrEditProduct(int? productid)
        {
            if(productid != null)
            {
                Product product = new Product
                {
                    ProductId = (int)productid
                };
                ViewBag.Edit = true;
                product = new BrowsingMenuContex(product,_db).FindProduct();
                return View(product);
            }
            else
            {
                ViewBag.Edit = false;
                return View();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                bool check;
                if(product.ProductId == 0)
                {
                    check=new EditingTheMenuContex(product,_db).AddProduct();
                }
                else
                {
                    check=new EditingTheMenuContex(product, _db).EditProduct();
                }
                if (check)
                {
                    return RedirectToAction("Home", "User", new { category = product.Category });
                }
            }
            if (product.ProductId != 0)
            {
                ViewBag.Edit = true;
            }
                ViewBag.error = "Wystąpił bład podczas edycji menu.";
            return View(product);
        }
        public ActionResult RemoveProduct(int productId)
        {
            Product product = new Product();
            product.ProductId = productId;
            product = new BrowsingMenuContex(product,_db).FindProduct();
            new EditingTheMenuContex(product,_db).RemoveProduct();
            return RedirectToAction("Home","User");
        }
    }
}