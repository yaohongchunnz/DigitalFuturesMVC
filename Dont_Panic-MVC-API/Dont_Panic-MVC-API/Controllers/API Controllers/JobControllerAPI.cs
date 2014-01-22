using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Dont_Panic_MVC_API.Models.API_Models;
using Microsoft.AspNet.Identity;


namespace Dont_Panic_MVC_API.Controllers.API_Controllers
{
    public class JobControllerAPI : ApiController
    {

        private JobAPI jobAPI = new JobAPI(); 

        // GET api/JobControllerAPI
        public IQueryable<Job> GetJobs()
        {
            return jobAPI.GetJobs(User.Identity.GetUserId());
        }

        // GET api/JobControllerAPI/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult GetJob(int id)
        {
            Job job = jobAPI.GetJob(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        // PUT api/JobControllerAPI/5
        public IHttpActionResult PutJob(int id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.jobid)
            {
                return BadRequest();
            }

            bool result = jobAPI.PutJob(id, job);

            if (!result)
                    return NotFound();


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/JobControllerAPI
        [ResponseType(typeof(Job))]
        public IHttpActionResult PostJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            jobAPI.PostJob(job);

            return CreatedAtRoute("DefaultApi", new { id = job.jobid }, job);
        }

        // DELETE api/JobControllerAPI/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult DeleteJob(int id)
        {
            Job job = jobAPI.GetJob(id);
            if (job == null)
            {
                return NotFound();
            }
            jobAPI.DeleteJob(job);
            return Ok(job);
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