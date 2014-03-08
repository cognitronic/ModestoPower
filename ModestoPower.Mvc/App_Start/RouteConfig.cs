using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RAM.Web.Routing;

namespace ModestoPower.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(
            new Route("{controller}/{action}/{id}",
                new RouteValueDictionary(
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
                    new ModestoPower.Mvc.App_Start.HyphenatedRouteHandler())
        );
        }
    }
}
