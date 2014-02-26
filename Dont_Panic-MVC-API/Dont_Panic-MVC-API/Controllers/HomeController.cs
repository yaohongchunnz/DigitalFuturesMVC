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
        public ActionResult Protect(LoginViewModel model)
        {
                if (model.Password == "shaft")
                {
                    Session["Login"] = model.UserName;
                }
            
            Session["Login"] = null;
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