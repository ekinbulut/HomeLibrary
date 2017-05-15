using System.Web.Mvc;
using System.Web.Routing;

namespace Library.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("Login", "{controller}/{action}/{id}", new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
            //    );

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
