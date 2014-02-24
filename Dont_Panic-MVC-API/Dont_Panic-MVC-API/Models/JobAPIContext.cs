using Dont_Panic_MVC_API.Models.API_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Dont_Panic_MVC_API.API_Models;

namespace Dont_Panic_MVC_API.Models
{
    public class APIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public APIContext() : base("name=DontPanicDB")
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<ServiceProviderDetails> ServiceProvidersDetails { get; set; }
        public DbSet<Email> emailAndUser { get; set; }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<JobService> jobService { get; set; }
        public DbSet<Photos> photos { get; set; }
        public DbSet<Region> region { get; set; }
        public DbSet<District> district { get; set; }
        public DbSet<Suburb> suburb { get; set; }
    }
}
