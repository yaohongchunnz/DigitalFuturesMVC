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
        public string username { get; set; }
        public DateTime submitDate { get; set; }
        public DateTime expireDate { get; set; }
    }

    public class ServiceProvider
    {
        [Key]
        public int provider_id { get; set; }

        public string business_name { get; set; }
        public string address { get; set; }

        // about service
        public string about { get; set; }
        public string services { get; set; }
        public string areas_serviced { get; set; }
        public string availability { get; set; }
        public string description { get; set; }

        // Service provider contact details
        public string contact_name { get; set; }
        public string email { get; set; }
        public string contact_number_1 { get; set; }
        public string contact_number_2 { get; set; }
        public string website_address { get; set; }

        //
    }

}