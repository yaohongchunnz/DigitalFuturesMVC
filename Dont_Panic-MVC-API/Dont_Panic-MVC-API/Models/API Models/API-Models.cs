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
        [Required]
        public string city { get; set; }
        [Required, StringLength(2048)]
        public string description { get; set; }
        [Required]
        public string jobtype { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public DateTime submitDate { get; set; }
        public DateTime expireDate { get; set; }
    }

   
}