using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dont_Panic_MVC_API.Models;
using System.Web.Mvc;

namespace Dont_Panic_MVC_API.Controllers.API_Controllers
{
    public class DropDownController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get(int dropdown, int selection)
        {
            APIContext context = new APIContext();
            if (dropdown == 1)
            {
                IQueryable<District> districts = context.district.Where(d => d.regionid == selection);

                List<SelectListItem> listItems = new List<SelectListItem>();
                foreach(District district in districts){
                    listItems.Add(new SelectListItem() { Value = district.districtid.ToString(), Text = district.district  });
                }

                return Request.CreateResponse(HttpStatusCode.OK, listItems, Configuration.Formatters.JsonFormatter);
            }
            else if(dropdown == 2){
                IQueryable<Suburb> suburbs = context.suburb.Where(d => d.districtid == selection);

                List<SelectListItem> listItems = new List<SelectListItem>();
                foreach (Suburb suburb in suburbs)
                {
                    listItems.Add(new SelectListItem() { Value = suburb.suburbid.ToString(), Text = suburb.suburb });
                }

                return Request.CreateResponse(HttpStatusCode.OK, listItems, Configuration.Formatters.JsonFormatter);
            }
            HttpError myCustomError = new HttpError("Invaild dropdown number or selection") { { "CustomErrorCode", 1 } };
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}