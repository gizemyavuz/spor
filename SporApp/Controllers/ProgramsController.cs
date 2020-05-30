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
using System.IO;
using SporApp.App_Start;

namespace SporApp.Controllers
{
    public class ProgramsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Programs
        public ActionResult Index()
        {
            return View(db.Programs.ToList());
        }

        // GET: Programs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
           
            if (program == null)
            {
                return HttpNotFound();
            }

            ProgramDetailView model = new ProgramDetailView
            {
                Id = program.Id,
                Calories = program.Calories,
                CreationTime = program.CreationTime,
                Description = program.Description,
                Link = program.Link,
                Name = program.Name,
                UpdateTime = program.UpdateTime,
                ImageUrl = program.ImageUrl
               // ImageUrl = string.IsNullOrEmpty(program.ImageUrl) ? string.Empty : "http://" + HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port + program.ImageUrl
            };

            return View(model);
        }

        // GET: Programs/Create
        [AdminAuthAction]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(ProgramCreateView program)
        {
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(program.File.FileName);
                string fileExtension = Path.GetExtension(program.File.FileName);
                fileName = DateTime.Now.ToString("yyyyMMdd") + "_" + fileName.Trim() + fileExtension;

                var path = Path.Combine(Server.MapPath("~/Content/programImages"), fileName);
                program.File.SaveAs(path);

                program.ImageUrl = "/Content/programImages/" + fileName;

                // aktarım yapıldı.
                Program _program = new Program {
                    Id = program.Id,
                    Description = program.Description,
                    Calories = program.Calories,
                    CreationTime = program.CreationTime,
                    ImageUrl = program.ImageUrl,
                    Link= program.Link,
                    Name = program.Name,
                    UpdateTime = program.UpdateTime
                };

                db.Programs.Add(_program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(program);
        }

        // GET: Programs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);

            if (program == null)
            {
                return HttpNotFound();
            }

            ProgramCreateView model = new ProgramCreateView {
                Id = program.Id,
                Description = program.Description,
                Calories = program.Calories,
                CreationTime = program.CreationTime,
                ImageUrl = program.ImageUrl,
                Link = program.Link,
                Name = program.Name,
                UpdateTime = program.UpdateTime,
            };
            return View(model);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(ProgramCreateView model)
        {
            Program program = new Program()
            {
                Id = model.Id,
                Description = model.Description,
                Calories = model.Calories,
                CreationTime = model.CreationTime,
                ImageUrl = model.ImageUrl,
                Link = model.Link,
                Name = model.Name,
                UpdateTime = model.UpdateTime,
            };

            if(model.File != null && model.File.FileName != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.File.FileName);
                string fileExtension = Path.GetExtension(model.File.FileName);
                fileName = DateTime.Now.ToString("yyyyMMdd") + "_" + fileName.Trim() + fileExtension;

                var path = Path.Combine(Server.MapPath("~/Content/programImages"), fileName);
                model.File.SaveAs(path);
                program.ImageUrl = "/Content/programImages/" + fileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(program);
        }

        // GET: Programs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.Programs.Find(id);
            db.Programs.Remove(program);
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
