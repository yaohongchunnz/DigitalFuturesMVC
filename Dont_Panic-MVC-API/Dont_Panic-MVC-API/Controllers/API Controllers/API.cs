using Dont_Panic_MVC_API.API_Models;
using Dont_Panic_MVC_API.Models;
using Dont_Panic_MVC_API.Models.API_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.AspNet.Identity;

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

        public void removeTokens(int amount, string userid)
        {
            ServiceProviderDetails sp = db.ServiceProvidersDetails.First(p => p.userId == userid);
            sp.tokens -= amount;
            db.SaveChanges();
        }

        public void addTokens(int amount, string userid)
        {
            ServiceProviderDetails sp = db.ServiceProvidersDetails.First(p => p.userId == userid);
            sp.tokens += amount;
            db.SaveChanges();
        }

        public int getTokens(string id){
            ServiceProviderDetails sp = db.ServiceProvidersDetails.First(p => p.userId == id);
            return sp.tokens;
        }

    }

    public class userAPI
    {
        private APIContext db = new APIContext();

        public UserDetail getDetails(string userid, string username)
        {
            UserDetail userD = new UserDetail();
            userD.email = db.emailAndUser.First(e => e.userName == username).email;
            UserDetails details = db.userDetails.First(d => d.userId == userid);
            userD.firstName = details.first_name;
            userD.lastName = details.last_name;
            userD.phoneNumber = details.phone_number;
            return userD;
        }

    }

    public class PhotoAPI
    {
        private APIContext db = new APIContext();

        public List<Photos> getPhotos(int jobid)
        {
            if (db.photos.Count(p => p.jobid == jobid) > 0)
            {
                return db.photos.Where(p => p.jobid == jobid).ToList();
            }
            return null;
        }

  

        public Photos getFirstPhoto(int jobid)
        {
           if (db.photos.Count(p => p.jobid == jobid) > 0){
               return db.photos.First(p => p.jobid == jobid);
           }
           return null;
       
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

        public bool ownsJob(int jobid, string id){

            if (db.jobService.Count(j => j.jobid == jobid && j.serviceProviderId == id) > 0) { 
            JobService s = db.jobService.First(j => j.jobid == jobid && j.serviceProviderId == id);
                
            if (s == null) return false;

            return true;
        }
         return false;   
        }

        public void deleteJobService(int jobid, string providerid)        {
            IQueryable<JobService> a = db.jobService.Where(j => j.jobid == jobid && j.serviceProviderId == providerid);
            db.jobService.Remove(a.First());
        }
    }
}
