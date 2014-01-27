﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dont_Panic_MVC_API.Models.API_Models;
using Dont_Panic_MVC_API.Controllers.API_Controllers;



namespace Dont_Panic_MVC_API.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: /ServiceProviderDetail/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /ServiceProviderDetail/Register
        [HttpPost]
        public string Register([Bind(Include = "provider_id,business_name,address, about, services, areas_serviced, description, availability, contact_name, email, contact_number_1, contact_number_2, website_address")] ServiceProvider service)
        {
            ServiceAPI api = new ServiceAPI();
            api.addProvider(service);
            return service.website_address;
        }
    }
}
