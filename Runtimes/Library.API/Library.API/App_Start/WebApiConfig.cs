using System.Net.Http.Headers;
using System.Web.Http;

namespace Library.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BookApi",
                routeTemplate: "api/book/{action}/{id}",
                defaults: new { controller = "BookApi" , id = RouteParameter.Optional }
            );



            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // restrict access for every Web API controller
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
