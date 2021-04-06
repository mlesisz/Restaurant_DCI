using System.Web.Mvc;
using Restaurant_DCI.Models;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB_Entities _db = new DB_Entities();
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Home");
        }

        public ActionResult Home(string category= "Dania główne")
        {
            Product product = new Product();
            product.Category = category;
            ViewBag.category = category;
            return View(new BrowsingMenuContex(product, _db).FindProducts());
        }

        
    }
}