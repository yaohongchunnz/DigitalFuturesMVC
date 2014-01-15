using Dont_Panic_MVC_API.Models.API_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dont_Panic_MVC_API.Models
{
    public class JobAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public JobAPIContext() : base("name=dontpanicDB")
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> User { get; set; }
    
    }
}
