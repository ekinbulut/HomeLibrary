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

                var Usermodel = new UserModel();
                Usermodel.Identity = Guid.NewGuid();
                Usermodel.Name = output.Name;
                Usermodel.LastLoginDate = output.LastLoginDate;
                Usermodel.Gender = output.Gender;
                Usermodel.Occupation = output.Occupation;
                Usermodel.UserId = output.UserId;

                Session.Add("Information", Usermodel);
                Session.Timeout = 5;

                // OWIN Auth
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, output.Name),
                        new Claim(ClaimTypes.Gender, output.Gender),
                        new Claim(ClaimTypes.Role,"User"), 
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
            if (!Session.IsNewSession || Session["Information"] != null)
            {
                Session.Remove("Information");

                Session.Clear();
            }

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Authentication");
        }
    }
}