﻿using System.Web.Mvc;
using System.Web.Routing;

namespace aspnet_mvc_razor_app
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "OnlyActionWithExtension",
                url: "{action}.aspx",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { action = @"(.*?)\.(aspx)" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
