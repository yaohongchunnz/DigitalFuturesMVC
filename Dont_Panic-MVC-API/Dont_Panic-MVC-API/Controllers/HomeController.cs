using Dont_Panic_MVC_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dont_Panic_MVC_API.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Protect()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Protect(ProtectLoginModel model)
        {
            if (model.Password == null) return View();

                if (model.Password == "shaft")
                {
                    Session["Login"] = model.Password;
                    Response.Redirect("~/Home");
                }
            
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}