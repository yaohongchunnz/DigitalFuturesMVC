using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Dont_Panic_MVC_API.API_Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [RegularExpression(@"^[a-zA-Z ,.'-]+$", ErrorMessage = "Please enter a valid First Name")]
        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [RegularExpression(@"^[a-zA-Z ,.'-]+$", ErrorMessage = "Please enter a valid Last Name")]
        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DontPanicDB")
        {
        }
    }
}