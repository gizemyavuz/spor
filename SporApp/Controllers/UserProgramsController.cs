using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SporApp.Entity;
using SporApp.Models;

namespace SporApp.Controllers
{
    public class UserProgramsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: UserPrograms
        public ActionResult Index()
        {
           var result = db.UserPrograms.Select(g => new UserProgramViewList {
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

            return View(result);
        }

        // GET: UserPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProgram userProgram = db.UserPrograms.Find(id);
            if (userProgram == null)
            {
                return HttpNotFound();
            }
            return View(userProgram);
        }

        // GET: UserPrograms/Create
        public ActionResult Create()
        {
            List<SelectListItem> degerprograms = (from i in db.Programs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerprograms;

            List<SelectListItem> degerusers = (from i in db.Users.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Name,
                                                      Value = i.Id.ToString()
                                                  }).ToList();
            ViewBag.dgrusers = degerusers;



            return View();
        }

        // POST: UserPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProgram userProgram)
        {
            if (ModelState.IsValid)
            {
                db.UserPrograms.Add(userProgram);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(userProgram);
        }

        // GET: UserPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProgram userProgram = db.UserPrograms.Find(id);
            if (userProgram == null)
            {
                return HttpNotFound();
            }
            return View(userProgram);
        }

        // POST: UserPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProgramId,UserId,ScheduleTime,Duration,Description,CreationTime,UpdateTime")] UserProgram userProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProgram);
        }

        // GET: UserPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProgram userProgram = db.UserPrograms.Find(id);
            if (userProgram == null)
            {
                return HttpNotFound();
            }
            return View(userProgram);
        }

        // POST: UserPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProgram userProgram = db.UserPrograms.Find(id);
            db.UserPrograms.Remove(userProgram);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
