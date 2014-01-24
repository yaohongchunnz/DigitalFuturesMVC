using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Dont_Panic_MVC_API.Models;
using System.Net.Http.Headers;
using Dont_Panic_MVC_API.Models.API_Models;
using Newtonsoft.Json;
using Dont_Panic_MVC_API.Controllers.API_Controllers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Dont_Panic_MVC_API.Controllers
{
   
    public class JobController : Controller
    {

        private JobAPI jobAPI = new JobAPI();

        public ActionResult Browse()
        {
            return View(jobAPI.GetAllJobs().ToList());
        }

        // GET: /Job/
        [Authorize]
        public ActionResult Index()
        {
            return View(jobAPI.GetUserJobs(User.Identity.GetUserId()).ToList());
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
         [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="jobid,title,description,city,jobtype")] Job jobmodel)
        {
            if (ModelState.IsValid)
            {
                jobmodel.UserId = User.Identity.GetUserId();
                jobAPI.PostJob(jobmodel);
                return RedirectToAction("Index");
            }

            return View(jobmodel);
        }

        // GET: /Job/Edit/5
         [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job jobmodel = jobAPI.GetJob(id);
            if (!User.Identity.GetUserId().Equals(jobmodel.UserId))
            {
                return RedirectToAction("Error");
            }

            if (jobmodel == null)
            {
                return HttpNotFound();
            }
            return View(jobmodel);
        }

        // POST: /Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

         [Authorize]
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="jobid,title,description,city,jobtype")] int id, Job jobmodel)
        {
            Job job = jobAPI.GetJob(id);
            if (!User.Identity.GetUserId().Equals(job.UserId))
            {
                return RedirectToAction("Error");
            }
            jobmodel.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                jobAPI.PutJob(id, jobmodel);
                return RedirectToAction("Index");
            }
            return View(jobmodel);
        }

        // GET: /Job/Delete/5

         [Authorize]
         [HttpGet]
        public ActionResult Delete(int id)
        {

            System.Diagnostics.Debug.WriteLine("In Delete "); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job jobmodel = jobAPI.GetJob(id);

            if (!User.Identity.GetUserId().Equals(jobmodel.UserId))
            {
                return RedirectToAction("Error");
            }

            if (jobmodel == null)
            {
                return HttpNotFound();
            }
            return View(jobmodel);
        }

        // POST: /Job/Delete/5
         [Authorize]
         [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Diagnostics.Debug.WriteLine("In DeleteConfirmed"); 

            Job jobmodel = jobAPI.GetJob(id);
            // Checking for matching UserID so only the user can delete their listing. 
            if (!(jobmodel.UserId.Equals(User.Identity.GetUserId())))
            {
                RedirectToAction("Error");
            }
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
