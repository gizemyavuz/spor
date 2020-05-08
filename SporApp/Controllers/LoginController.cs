using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporApp.Entity;
using System.Web.Security;

namespace SporApp.Controllers
{
    public class LoginController : Controller
    {
       private DataContext db = new DataContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Email == u.Email && x.Password == u.Password);
            if(bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();  
            }
        }
    }
}