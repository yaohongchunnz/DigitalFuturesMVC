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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

using System.Configuration;
using System.IO;
using Dont_Panic_MVC_API.API_Models;

namespace Dont_Panic_MVC_API.Controllers


{
   
    public class JobController : Controller
    {

        private JobAPI jobAPI = new JobAPI();

        public ActionResult Browse()
        {
            return View(jobAPI.GetAllJobs().ToList());
        }

        [Authorize]
        public ActionResult Previous()
        {
            return View(jobAPI.GetUserJobs(User.Identity.GetUserId()).ToList());
        }

        // GET: /Job/
        [Authorize]
        public ActionResult Index()
        {
            IdentityManager im = new IdentityManager();

            if (im.UserContainsRole(User.Identity.GetUserId(),"Provider"))
            {
                JobServiceAPI api = new JobServiceAPI();
                IQueryable<JobService> jobServices = api.getProvidersJobs(User.Identity.GetUserId());
                    
                List<Job> jobs = new List<Job>();
                APIContext context = new APIContext();
                foreach(var jobService in jobServices){
                    jobs.Add(context.Jobs.First(i => i.jobid == jobService.jobid));
                }
                return View(jobs);            
            }
            return View(jobAPI.GetCurrentUserJobs(User.Identity.GetUserId()).ToList());
        }

        // POST: /Job/RepostJob
        [HttpPost]
        public ActionResult RepostJob(int jobid)
        {
            JobAPI api = new JobAPI();

            Job job = api.GetJob(jobid);
            if (job != null)
            {
                job.expireDate = DateTime.Now.AddDays(2);
            }
            return RedirectToAction("/");
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

        // POST: /Job/AcquireLead
        public ActionResult AcquireLead(int jobid)
        {
            APIContext db = new APIContext();
            IQueryable<JobService> jobServices = db.jobService.Where(a => a.jobid == jobid);
            

            if (jobServices != null) { 
                foreach (JobService jobService in jobServices)
                {
                    if (jobService.serviceProviderId == User.Identity.GetUserId())
                    {
                        return RedirectToAction("/");
                    }
                }
            }

            Job job = jobAPI.GetJob(jobid);
            if (job.leadsAccquired < 3)
            {

                job.leadsAccquired = job.leadsAccquired + 1;
                jobAPI.PutJob(jobid, job);

                JobService servicejob = new JobService();
                servicejob.jobid = jobid;
                servicejob.serviceProviderId = User.Identity.GetUserId();
                db.jobService.Add(servicejob);
                db.SaveChanges();
            }
            
            return RedirectToAction("/");
        }

        // GET: /Job/Create
        public ActionResult Create()
        {
            ViewBag.City = (new RegionDropDown()).RegionList;
            return View();
        }

        // POST: /Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewJob viewJob)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account",
                           new { returnUrl = "/Job/Create", FormMethod.Get});
            }
            
            Job jobmodel = new Job();

            if (ModelState.IsValid)
            {
               // Console.WriteLine(fakejobmodel.region.Text.ToString());

                RegionDropDown regions = new RegionDropDown();
                
                jobmodel.region = regions.RegionList.ElementAt(viewJob.region-1).Text;
                jobmodel.district =  "qwerty";
                jobmodel.suburb = "qwerty";
                jobmodel.description = viewJob.description;
                jobmodel.jobtype = viewJob.jobtype;
                jobmodel.title = viewJob.title;

                jobmodel.submitDate = DateTime.Now;
                
                switch (viewJob.duration)
                {
                    case "Now (24 Hrs)":
                        jobmodel.expireDate = jobmodel.submitDate.AddDays(1);
                        break;
                    case "Soon (48 Hrs)":
                        jobmodel.expireDate = jobmodel.submitDate.AddDays(2);
                        break;
                    case "Whenever (72 Hrs +)":
                        jobmodel.expireDate = jobmodel.submitDate.AddDays(3);
                        break;
                    default:
                        jobmodel.expireDate = jobmodel.submitDate.AddDays(1);
                        break; 
                }

                jobmodel.UserId = User.Identity.GetUserId();
                jobmodel.username = User.Identity.GetUserName();
                jobAPI.PostJob(jobmodel);

                APIContext db = new APIContext();

                

                List<string> images = ImageUpload();
                foreach(string image in images){
                    Photos photo = new Photos();
                    photo.jobid = jobmodel.jobid;
                    photo.photo = image;
                    db.photos.Add(photo);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City = (new RegionDropDown()).RegionList;

            return View(viewJob);
        }

        public List<string> ImageUpload()
        {

            HttpPostedFileBase file = Request.Files["images"];

            List<string> photos = new List<string>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase image = Request.Files[i];

                if (file.ContentLength == 0)
                    continue;

                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                   image.FileName, image.ContentType, image.ContentLength);
                // TODO: actually save the image to Azure blob storage

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

                var blobStorage = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobStorage.GetContainerReference("job-images");
                if (container.CreateIfNotExist())
                {
                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);
                }
                string uniqueBlobName = string.Format("job-images/image_{0}{1}",
                Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
                CloudBlockBlob blob = blobStorage.GetBlockBlobReference(uniqueBlobName);

                blob.Properties.ContentType = image.ContentType;
                blob.UploadFromStream(image.InputStream);

                photos.Add(blob.Uri.ToString());
            }
            return photos;
        }


        [Authorize]
        public string AuthCreate(string title){


          
         //   if (ModelState.IsValid)
         //   {
        //        jobmodel.submitDate = DateTime.Today;
         //       jobmodel.expireDate = DateTime.Today.AddDays(2);
         //       jobmodel.UserId = User.Identity.GetUserId();
         //       jobmodel.username = User.Identity.GetUserName();
        //        jobAPI.PostJob(jobmodel);
      //          return ("Is valid");               // return RedirectToAction("Index");
        //    }
            return title;
          //  return RedirectToAction("Create", jobmodel);
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
