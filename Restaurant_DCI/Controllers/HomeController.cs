using System.Web.Mvc;
using Restaurant_DCI.Models;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Home","User");
        }

        
    }
}