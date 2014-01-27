using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dont_Panic_MVC_API.Models.API_Models;


namespace Dont_Panic_MVC_API.Controllers
{
    public class ServiceProviderController : Controller
    {

        // GET: /ServiceProviderDetail/Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // 
        [HttpPost]
        public string Index([Bind(Include = "provider_id,business_name,address, about, services, areas_serviced, availability, contact_name, email, contact_number_1, contact_number_2, website_address")] ServiceProvider service)
        {




            return service.website_address;
        }
    
    }


}
