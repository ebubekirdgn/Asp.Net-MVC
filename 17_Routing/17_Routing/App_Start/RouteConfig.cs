using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _17_Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Domainden sonra Anasayfa yazınca 'Home/Index' action'ına gider.
            routes.MapRoute(
                name: "anasayfa",
                url: "anasayfa",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
               name: "hakkimizda",
               url: "hakkimizda",
               defaults: new { controller = "Home", action = "Contact" }
           );

            routes.MapRoute(
               name: "iletisim",
               url: "iletisim",
               defaults: new { controller = "Home", action = "About" }
           );

            routes.MapRoute(
                name: "Belge",
                url: "{controller}/Belge/{belgeno}",
                defaults: new { controller = "Home", action = "Index", belgeno = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
