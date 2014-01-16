﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Dont_Panic_MVC_API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DontPanicDB")
        {
        }

        public System.Data.Entity.DbSet<Dont_Panic_MVC_API.Models.JobModel> JobModels { get; set; }
    }
}