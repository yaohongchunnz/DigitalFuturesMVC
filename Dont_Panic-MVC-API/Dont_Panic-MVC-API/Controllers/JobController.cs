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

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;

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
          //  if (!User.Identity.IsAuthenticated)
          //  {
          //      return RedirectToAction("Login", "Account",
          //                 new { returnUrl = "/Job/AuthCreate", FormMethod.Post });
          //  }
            
            Job jobmodel = new Job();

            if (ModelState.IsValid)
            {
               // Console.WriteLine(fakejobmodel.region.Text.ToString());

                RegionDropDown regions = new RegionDropDown();
                
                jobmodel.region = regions.RegionList.ElementAt(viewJob.region-1).Text;
//                jobmodel.district = 
//                jobmodel.suburb = 
                jobmodel.description = viewJob.description;
                jobmodel.jobtype = viewJob.jobtype;
                jobmodel.title = viewJob.title;
                jobmodel.username = viewJob.username;

                jobmodel.submitDate = DateTime.Now;
               // jobmodel.expireDate = DateTime.Today.AddDays(2);
                jobmodel.UserId = User.Identity.GetUserId();
                jobmodel.username = User.Identity.GetUserName();
                jobAPI.PostJob(jobmodel);
                return RedirectToAction("Index");
            }
            ViewBag.City = (new RegionDropDown()).RegionList;

            return View(viewJob);
        }

        [HttpPost]
        public ActionResult ImageUpload()
        {
            string path = @"D:\Temp\";

            var image = Request.Files["image"];
            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {

                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                    image.FileName, image.ContentType, image.ContentLength);
                // TODO: actually save the image to Azure blob storage

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

                CloudBlobClient blobStorage = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobStorage.GetContainerReference("jobimages");
                if (container.CreateIfNotExists())
                {
                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);
                }
                string uniqueBlobName = string.Format("productimages/image_{0}{1}",
                Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
                //CloudBlockBlob blob = blobStorage.GetBlockBlobReference(uniqueBlobName);
                
                

              //  blob.Properties.ContentType = image.ContentType;
              //  blob.UploadFromStream(image.InputStream);


             }
                return View(); 
               
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
