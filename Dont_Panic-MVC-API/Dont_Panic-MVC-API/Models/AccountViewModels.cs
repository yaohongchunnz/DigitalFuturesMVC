using System.ComponentModel.DataAnnotations;

namespace Dont_Panic_MVC_API.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [System.Web.Mvc.Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [System.Web.Mvc.Remote("doesEmailExist", "Account", HttpMethod = "POST", ErrorMessage = "Email already exists.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){7,}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string phoneNumber { get; set; }

        public string name { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [RegularExpression(@"^[a-zA-Z ,.'-]+$", ErrorMessage = "Please enter a valid First Name")]
        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [RegularExpression(@"^[a-zA-Z,.'-]+$", ErrorMessage = "Please enter a valid Last Name")]
        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "User name")]
        [System.Web.Mvc.Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [System.Web.Mvc.Remote("doesEmailExist", "Account", HttpMethod = "POST", ErrorMessage = "Email already exists.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){7,}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string phoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterProviderViewModel
    {
        [Required]
        [Display(Name = "Business Name")]
        public string businessName { get; set; }

        [Required]
        [Display(Name = "User name")]
        [System.Web.Mvc.Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [System.Web.Mvc.Remote("doesEmailExist", "Account", HttpMethod = "POST", ErrorMessage = "Email already exists.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){7,}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string contact_number_1 { get; set; }
        public string contact_number_2 { get; set; }
        public string website_address { get; set; }
    }
}
