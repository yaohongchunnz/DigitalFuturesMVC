using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dont_Panic_MVC_API.Models
{
    public class JobModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string jobtype { get; set; }
    }

    public class JobContext : DbContext
    {
        public DbSet<JobModel> Jobs { get; set; }
    }
}