using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Dont_Panic_MVC_API.API_Models;

namespace Dont_Panic_MVC_API.Controllers.API_Controllers
{
    public class tokenController : ApiController
    {
        public string Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                IdentityManager im = new IdentityManager();
                if (im.UserContainsRole(User.Identity.GetUserId(), "Provider"))
                {
                    ServiceAPI api = new ServiceAPI();
                    return "<token>" + api.getTokens(User.Identity.GetUserId()) + "</token>";
                }
            }

            return "<token>0</token>";
        }
    }
}