using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Library.Business.Services.Authantication.Dtos;
using Library.Mvc.Models;
using Library.Mvc.Providers;
using Microsoft.Owin.Security;

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


                #region [ OWIN ]

                // OWIN Auth
                var claims = new ClaimsIdentity(new[] {
                        new Claim("Name", output.Name),
                        new Claim("Gender", output.Gender),
                        new Claim("Identity",Guid.NewGuid().ToString()),
                        new Claim("LastLoginDate",output.LastLoginDate.ToString()),
                        new Claim("Occupation",output.Occupation),
                        new Claim("UserId",output.UserId.ToString()),
                        new Claim("Role",output.Role),
                    },
                    "ApplicationCookie");

                var properties = new AuthenticationProperties();

                properties.IsPersistent = model.RememberMe;
                properties.ExpiresUtc   = DateTimeOffset.UtcNow.AddDays(1.0);

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(properties, claims);

                #endregion


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