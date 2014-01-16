using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dont_Panic_MVC_API.Models.API_Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(15)]
        public string username { get; set; }
        
        public int good_feedback { get; set; }
        public int neutral_feedback { get; set; }
        public int bad_feedback { get; set; }

        public virtual List<Job> jobs { get; set; }
    }

    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string title { get; set; }
        public string city { get; set; }
        [Required, StringLength(2048)]
        public string description { get; set; }
        public string jobtype { get; set; }

    }
}