using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_DCI.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB_Entities _db = new DB_Entities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
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
                var check = new RegisterContex(_user, _db).DoIt();
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
        public ActionResult Login(LoginViewModel LoginData/*string email, string password*/)
        {
            if (ModelState.IsValid)
            {
                /*Account _user = new Account
                {
                    Email = email,
                    Password = password
                };*/
                bool SucessfulLogin = new LoginContex(LoginData, _db).DoIt();
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

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }

    public class LoginContex
    {
        public ILoginUser User { get; private set; }
        public DB_Entities Db { get; private set; }
        public LoginContex(LoginViewModel user, DB_Entities _db)
        {
            User = user;
            Db = _db;
        }
        public bool DoIt()
        {
            return User.Login(Db);
        }

    }

    public class RegisterContex
    {
        public IRegisterUser User { get; private set; }
        public DB_Entities Db { get; private set; }
        public RegisterContex(Account user, DB_Entities _db)
        {
            User = user;
            Db = _db;
        }
        public bool DoIt()
        {
            return User.Register(Db);
        }
    }

}