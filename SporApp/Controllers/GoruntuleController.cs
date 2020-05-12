using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporApp.App_Start;
using SporApp.Entity;
using SporApp.Models;

namespace SporApp.Controllers
{
    [AuthAction]
    public class GoruntuleController : Controller
    {
      
        private DataContext db = new DataContext();
        // GET: Goruntule
        public ActionResult Index()
        {
           // var item = ;
            var degerler = db.Users.ToList();
            
            return View(degerler);
        }

        public ActionResult goruntule()
        {
            int userId = Convert.ToInt32(HttpContext.User.Identity.Name);

            var deger = db.UserPrograms.Where(m=>m.UserId == userId).
                 Select(g => new UserProgramViewList
                 {
                     CreationTime = g.CreationTime,
                     Description = g.Description,
                     Duration = g.Duration,
                     Id = g.Id,
                     Name = g.User.Name + " " + g.User.Surname,
                     ProgramId = g.ProgramId,
                     ProgramName = g.Program.Name,
                     ScheduleTime = g.ScheduleTime,
                     UpdateTime = g.UpdateTime,
                     UserId = g.UserId

                 }).ToList();
            return View(deger);
        }
        public ActionResult Indexx()
        {
            var programgoruntule = db.UserPrograms.Select(i => new UserProgramViewList()
            {
                UserId = i.UserId,
                Name = i.User.Name,
                ProgramId = i.ProgramId,
                ProgramName = i.Program.Name,
                Description=i.Description

            }).ToList();

            return View(programgoruntule);
        }
      
    }
}