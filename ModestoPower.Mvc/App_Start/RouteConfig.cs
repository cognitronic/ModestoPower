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
            new Route("Blog/{category}/{title}",
                new RouteValueDictionary(
                    new
                    {
                        controller = "Blog",
                        action = "ByTitle"
                    }),
                    new HyphenatedRouteHandler())
        );

            routes.Add(
            new Route("Blog/{category}",
                new RouteValueDictionary(
                    new { controller = "Blog", action = "ByCategory" }),
                    new HyphenatedRouteHandler())
        );

            routes.Add(
            new Route("Blog",
                new RouteValueDictionary(
                    new { controller = "Blog", action = "Index" }),
                    new HyphenatedRouteHandler())
        );

            routes.Add(
            new Route("Instructors/{instructor}",
                new RouteValueDictionary(
                    new { controller = "Instructors", action = "GetInstructor" }),
                    new ModestoPower.Mvc.App_Start.HyphenatedRouteHandler())
                    );

            routes.Add(
            new Route("Programs/{program}",
                new RouteValueDictionary(
                    new { controller = "Programs", action = "GetProgram" }),
                    new ModestoPower.Mvc.App_Start.HyphenatedRouteHandler())
                    );

            routes.Add(
            new Route("{controller}/{action}/{id}",
                new RouteValueDictionary(
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
                    new ModestoPower.Mvc.App_Start.HyphenatedRouteHandler())
            );
        }
    }
}
