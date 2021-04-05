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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account _user)
        {
            if (ModelState.IsValid)
            {
                var check = new RegisterContex(_user, _db).SuccessfulRegiser();
                if (check == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Podany email jest już używany.";
                    return View();
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel LoginData)
        {
            if (ModelState.IsValid)
            {
                bool SucessfulLogin = new LoginContex(LoginData, _db).SuccessfulLogin();
                if (SucessfulLogin)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Logowanie nieudane.";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}