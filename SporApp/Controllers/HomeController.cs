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
    }
}