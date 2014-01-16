using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dont_Panic_MVC_API.Models
{
    public class JobModel
    {
        
        [Key] public int jobid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string jobtype { get; set; }
    }

}