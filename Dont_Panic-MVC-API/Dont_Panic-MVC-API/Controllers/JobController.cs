using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dont_Panic_MVC_API.Models;

namespace Dont_Panic_MVC_API.Controllers
{
    public class JobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Job/
        public ActionResult Index()
        {
            return View(db.JobModels.ToList());
        }

        // GET: /Job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobModel jobmodel = db.JobModels.Find(id);
            if (jobmodel == null)
            {
                return HttpNotFound();
            }
            return View(jobmodel);
        }

        // GET: /Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="jobid,title,description,city,jobtype")] JobModel jobmodel)
        {
            if (ModelState.IsValid)
            {
                db.JobModels.Add(jobmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobmodel);
        }

        // GET: /Job/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobModel jobmodel = db.JobModels.Find(id);
            if (jobmodel == null)
            {
                return HttpNotFound();
            }
            return View(jobmodel);
        }

        // POST: /Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="jobid,title,description,city,jobtype")] JobModel jobmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobmodel);
        }

        // GET: /Job/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobModel jobmodel = db.JobModels.Find(id);
            if (jobmodel == null)
            {
                return HttpNotFound();
            }
            return View(jobmodel);
        }

        // POST: /Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobModel jobmodel = db.JobModels.Find(id);
            db.JobModels.Remove(jobmodel);
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
