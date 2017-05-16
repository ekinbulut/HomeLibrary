using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Library.Business.Services.Authantication.Dtos;
using Library.Mvc.Models;
using Library.Mvc.Providers;

namespace Library.Web.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        protected ServiceProvider Services;

        public AuthenticationController()
        {
            Services = new ServiceProvider();
        }
        //LOGIN PAGE
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            
            var output = Services.AuthService.Authenticate(new UserInputDto
            {
                User = new UserDto
                {
                    Username = model.Username,
                    Password = model.Password
                }
            });

            if (output != null)
            {
                // OWIN Auth
                var identity = new ClaimsIdentity(new[] {
                        new Claim("Name", output.Name),
                        new Claim("Gender", output.Gender),
                        new Claim("Identity",Guid.NewGuid().ToString()), 
                        new Claim("LastLoginDate",output.LastLoginDate.ToString()), 
                        new Claim("Occupation",output.Occupation), 
                        new Claim("UserId",output.UserId.ToString()), 
                    },
                    "ApplicationCookie");


                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Authentication");
        }
    }
}