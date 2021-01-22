using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Album",
                url: "{name}-a-{id}",
                defaults: new { controller = "Home", action = "Album" }
                );

            routes.MapRoute(
                name: "Genre",
                url: "{name}-g-{id}",
                defaults: new { controller = "Home", action = "Genre" }
                );

            routes.MapRoute(
                name: "Artist",
                url: "{name}-r-{id}",
                defaults: new { controller = "Home", action = "Artist" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
