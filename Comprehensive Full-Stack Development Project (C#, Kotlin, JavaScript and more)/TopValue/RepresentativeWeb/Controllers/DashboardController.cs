using BLL;
using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Controllers
{
    public class DashboardController : Controller
    {
        private LoginBL loginBl = new LoginBL();

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (loginBl.LoginSuccessful(user))
            {
                Session["User"] = user;
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
    }
}