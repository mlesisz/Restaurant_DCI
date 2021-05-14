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

        public ActionResult ExecutionOfTheOrder(int? orderId)
        {
            if(orderId != null)
            {
                Order order = new Order { OrderId = (int)orderId };
                order = new BrowsingOrdersContex(order,_db).FindOrder();
                return View(order);
            }
            else
            {
                return RedirectToAction("Orders","Chef");
            }
        }
        public ActionResult Recipe()
        {
            return View();
        }
        
        public ActionResult MakeOrderItem(int orderItemId, int orderId)
        {
            OrderItem orderItem = new OrderItem() { OrderItemId = orderItemId };
            new CompleteTheOrderContex(orderItem, _db).MakeOrderItem();
            return RedirectToAction("ExecutionOfTheOrder", "Chef",new { orderId });
        }

        public ActionResult Orders(OrderState orderState = OrderState.New)
        {
            Account chef = new Account();
            chef.Permissions = (Permissions)Session["Permissions"];
            List<Order> orders = new BrowsingOrdersContex(new Order { OrderState = orderState }, chef, _db).FindOrders();
            ViewBag.OrderState = orderState.GetDisplayName();
            return View(orders);
        }
        [HttpPost]
        public ActionResult ViewOrders(OrderState orderState = OrderState.New)
        {
            Account chef = new Account();
            chef.Permissions = (Permissions)Session["Permissions"];
            List<Order> orders = new BrowsingOrdersContex(new Order { OrderState = orderState }, chef, _db).FindOrders();
            ViewBag.OrderState = orderState.GetDisplayName();
            return PartialView("_Orders",orders);
        }

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