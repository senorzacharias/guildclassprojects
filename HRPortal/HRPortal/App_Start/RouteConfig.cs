using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HRPortal.Controllers;

namespace HRPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Application",
            url: "apply",
            defaults: new { controller = "Home", action = "Apply" }
        );

            routes.MapRoute(
                name: "Policy",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Policy", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
