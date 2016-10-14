using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Library.Mvc;

namespace Library.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Registeration.RegisterBase();
        }
    }
}
