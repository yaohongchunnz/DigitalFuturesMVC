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
}