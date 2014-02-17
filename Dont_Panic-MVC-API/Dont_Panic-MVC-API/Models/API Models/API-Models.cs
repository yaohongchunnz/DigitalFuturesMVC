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
        public string region { get; set; }
        [Required]
        public string district { get; set; }
        [Required]
        public string suburb { get; set; }
        [Required, StringLength(2048)]
        public string description { get; set; }
        [Required]
        public string jobtype { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string username { get; set; }
        public string photo { get; set; }
        [Required]
        public DateTime submitDate { get; set; }
        public DateTime expireDate { get; set; }
    }

    public class JobService
    {
        [Key]
        public int id { get; set; }
        public int jobid { get; set; }
        public int serviceProviderId { get; set; }
    }

   
}