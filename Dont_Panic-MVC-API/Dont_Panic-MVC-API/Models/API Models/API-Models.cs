using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dont_Panic_MVC_API.Models.API_Models
{


    public class Job
    {
        [Key]
        public int jobid { get; set; }
        [Required, StringLength(50)]
        public string title { get; set; }
        public string city { get; set; }
        [Required, StringLength(2048)]
        public string description { get; set; }
        public string jobtype { get; set; }
        public string UserId { get; set; }

    }
}