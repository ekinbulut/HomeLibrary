using System.Web.Mvc;
using Library.Mvc.Models;
using Library.Mvc.Providers;

namespace Library.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ServiceProvider Services;
        protected UserModel Usermodel;

        protected BaseController()
        {
            Services = new ServiceProvider();
        }

        public abstract ActionResult Index();

    }
}
