using SporApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporApp.Controllers
{
    public class HomeController : Controller
    {

        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuPartial()
        {
            bool isAdmin = false;
            if (HttpContext != null && !string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                isAdmin = Convert.ToBoolean(HttpContext.User.Identity.Name.Split(',')[1]);
            }
            ViewBag.isAdmin = isAdmin;

            return PartialView("MenuPartial");
        }
    }
}