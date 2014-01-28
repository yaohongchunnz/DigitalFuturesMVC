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

    public class ServiceProvider
    {
        [Key]
        public int provider_id { get; set; }
        [Required]
        public string business_name { get; set; }
        [Required]
        public string address { get; set; }

        // about service
        [Required]
        public string about { get; set; }
        [Required]
        public string services { get; set; }
        [Required]
        public string areas_serviced { get; set; }
        [Required]
        public string availability { get; set; }
        [Required]
        public string description { get; set; }

        // Service provider contact details
        [Required]
        public string contact_name { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required]
        [Display(Name="Email")]
        public string email { get; set; }
        [Required]
        public string contact_number_1 { get; set; }
        public string contact_number_2 { get; set; }
        public string website_address { get; set; }
    }
}