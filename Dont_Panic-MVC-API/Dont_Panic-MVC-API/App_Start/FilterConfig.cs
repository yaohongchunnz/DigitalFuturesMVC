﻿using System.Web;
using System.Web.Mvc;

namespace Dont_Panic_MVC_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
