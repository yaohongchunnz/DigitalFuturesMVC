using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dont_Panic_MVC_API.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Dont_Panic_MVC_API.Models.API_Models;
using Newtonsoft.Json;
using Dont_Panic_MVC_API.Controllers.API_Controllers;
using System.Web.Http;

namespace Dont_Panic_MVC_API.Controllers
{
    public class JobController : Controller
    {

        private JobAPI jobAPI = new JobAPI();

        // GET: /Job/
        public ActionResult Index()
        {
            return View(jobAPI.GetJobs().ToList());
        }

        // GET: /Job/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job job = jobAPI.GetJob(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
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
        public ActionResult Create([Bind(Include="jobid,title,description,city,jobtype")] Job jobmodel)
        {
            if (ModelState.IsValid)
            {
                jobAPI.PostJob(jobmodel);
                return RedirectToAction("Index");
            }

            return View(jobmodel);
        }

        // GET: /Job/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job jobmodel = jobAPI.GetJob(id);
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
        public ActionResult Edit([Bind(Include="jobid,title,description,city,jobtype")] int id, Job jobmodel)
        {
            if (ModelState.IsValid)
            {
                jobAPI.PutJob(id, jobmodel);
                return RedirectToAction("Index");
            }
            return View(jobmodel);
        }

        // GET: /Job/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job jobmodel = jobAPI.GetJob(id);
            if (jobmodel == null)
            {
                return HttpNotFound();
            }
            return View(jobmodel);
        }

        // POST: /Job/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job jobmodel = jobAPI.GetJob(id);
            jobAPI.DeleteJob(jobmodel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                jobAPI.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
