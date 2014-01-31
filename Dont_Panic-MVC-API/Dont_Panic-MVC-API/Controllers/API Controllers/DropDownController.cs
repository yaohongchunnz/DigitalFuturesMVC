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
            if (dropdown == 1 && selection == 11)
            {
                WellingtonDistrictDropDown values = new WellingtonDistrictDropDown();
                return Request.CreateResponse(HttpStatusCode.OK, values.DistrictList, Configuration.Formatters.JsonFormatter);
            }
            else if(dropdown == 2 && selection == 8){
                WellingtonSuburbDropDown values = new WellingtonSuburbDropDown();
                return Request.CreateResponse(HttpStatusCode.OK, values.SuburbList, Configuration.Formatters.JsonFormatter);
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