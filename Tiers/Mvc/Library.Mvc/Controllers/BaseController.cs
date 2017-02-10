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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            if (session.IsNewSession || session["Information"] == null)
            {
                filterContext.Result = RedirectToAction("Index", "Authentication");

            }

            Usermodel = Session["Information"] as UserModel;

            base.OnActionExecuting(filterContext);
        }

        public abstract ActionResult Index();

    }
}
