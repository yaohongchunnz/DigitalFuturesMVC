using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dont_Panic_MVC_API.Controllers
{
    public class JobController : Controller
    {
        //
        // GET: /Job/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Job/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Job/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Job/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //When job form is filled out and the post job button is pressed
                //This is where we post the job details to the database.
                
                return RedirectToAction("Index");//Then redirect them to somewhere else.
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Job/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Job/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Job/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
