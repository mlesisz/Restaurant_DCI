using Restaurant_DCI.Contex;
using Restaurant_DCI.Models;
using Restaurant_DCI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_DCI.Controllers
{
    public class AccountController : Controller
    {
        private readonly DB_Entities _db = new DB_Entities();
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
                    return RedirectToAction("Index","Home");
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
                Account loginAccount = new Account
                {
                    Email = LoginData.Email,
                    Password = LoginData.Password
                };
                bool SucessfulLogin = new LoginContex(loginAccount, _db).SuccessfulLogin();
                if (SucessfulLogin)
                {
                    return RedirectToAction("Index","Home");
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