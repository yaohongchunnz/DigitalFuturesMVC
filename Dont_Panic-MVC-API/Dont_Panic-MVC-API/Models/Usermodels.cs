using Dont_Panic_MVC_API.API_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dont_Panic_MVC_API.Models
{
    public class Email
    {
        [Key]
        public string email { get; set; }
        public string userName { get; set; }
    }
    public class UserDetails
    {
        [Key]
        [Required]
        public string userId { get; set; }

        [RegularExpression(@"^[a-zA-Z ,.'-]+$", ErrorMessage = "Please enter a valid First Name")]
        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [RegularExpression(@"^[a-zA-Z ,.'-]+$", ErrorMessage = "Please enter a valid Last Name")]
        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){9,}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string phone_number { get; set; }
    }

    public class ServiceProviderDetails
    {
        [Required]
        [Key]
        public string userId { get; set; }
                
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

        [Required]
        public string contact_number_1 { get; set; }
        public string contact_number_2 { get; set; }
        public string website_address { get; set; }

        public int tokens { get; set; }
    }

    public class UsersProviderDetails
    {
        [Required]
        [Key]
        public string userId { get; set; }

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

        [Required]
        public string contact_number_1 { get; set; }
        public string contact_number_2 { get; set; }
        public string website_address { get; set; }

        public string email { get; set; }
        public string username { get; set; }
    }
}