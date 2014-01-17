using Dont_Panic_MVC_API.Models;
using Dont_Panic_MVC_API.Models.API_Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Dont_Panic_MVC_API.Controllers.API_Controllers
{
    public class JobAPI
    {
        // Database
        private JobAPIContext db = new JobAPIContext();

        // Get jobs from database.
        public IQueryable<Job> GetJobs()
        {
            return db.Jobs;
        }

        // Get job from database with certain id
        public Job GetJob(int id)
        {
            return db.Jobs.Find(id);
        }

        // Modify existing job in database.
        public bool PutJob(int id, Job job)
        {
            db.Entry(job).State = EntityState.Modified;

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
}
