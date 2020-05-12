using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporApp.Entity;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace SporApp.Controllers
{
    public class LoginController : Controller
    {
       private DataContext db = new DataContext();

        // GET: Login
       
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home/Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u,string returnurl)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Email == u.Email && x.Password == u.Password);
            if (bilgiler != null)
            {
                
                FormsAuthentication.SetAuthCookie(bilgiler.Id + "," + bilgiler.IsAdmin.ToString(), true);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "EMail veya şifre hatalı!");
            }
            return View(u);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}