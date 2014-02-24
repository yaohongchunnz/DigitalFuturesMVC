using Dont_Panic_MVC_API.API_Models;
using Dont_Panic_MVC_API.Models;
using Dont_Panic_MVC_API.Models.API_Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

// File contains
    // Service Provider API
    // Jobn API

namespace Dont_Panic_MVC_API.Controllers.API_Controllers
{

    // API for querying the database for Service Providers.
    public class ServiceAPI
    {
        private APIContext db = new APIContext();

        // Inserts service provider into the database.
        public void addProvider(ServiceProviderDetails provider)
        {
            db.ServiceProvidersDetails.Add(provider);
            db.SaveChanges();
        }
    }

    public class PhotoAPI
    {
        private APIContext db = new APIContext();

        public IQueryable<Photos> getPhotos(int jobid)
        {
            return db.photos.Where(p => p.jobid == jobid);
        }

        public Photos getFirstPhoto(int jobid)
        {
            return db.photos.First(p => p.jobid == jobid);
        }
    }

    // API for querying Jobs in the database.
    public class JobAPI
    {
        // Database
        private APIContext db = new APIContext();
        
        // Returns All Jobs in the database.
        public IQueryable<Job> GetAllJobs()
        {
            return db.Jobs;
        }

        // Get jobs from database.
        public IQueryable<Job> GetUserJobs(string UserId)
        {
            return db.Jobs.Where(j => j.UserId == UserId);
        }

        public IQueryable<Job> GetCurrentUserJobs(string UserId)
        {
            IQueryable<Job> jobs = db.Jobs.Where(j => j.UserId == UserId);
            return jobs.Where(j => j.expireDate > DateTime.Now);
        }

        // Get job from database with certain id
        public Job GetJob(int id)
        {
            return db.Jobs.Find(id);
        }

        // Modify existing job in database.
        public bool PutJob(int id, Job job)
        {
            Job databaseJob = GetJob(id);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        // POST api/JobControllerAPI
        public void PostJob(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
        }

        // DELETE api/JobControllerAPI/5
        public void DeleteJob(Job job)
        {
            db.Jobs.Remove(job);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.jobid == id) > 0;
        }
    }


    public class JobServiceAPI
    {
        private APIContext db = new APIContext();

        public IQueryable<JobService> getProvidersJobs(string providerId){
            return db.jobService.Where(j => j.serviceProviderId == providerId);
        }

        public IQueryable<JobService> getJobsProviders(int jobid)
        {
            return db.jobService.Where(j => j.jobid == jobid);
        }
    }
}
