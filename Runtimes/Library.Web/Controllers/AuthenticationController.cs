using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Library.Business.Services.Authantication.Dtos;
using Library.Common.Helpers;
using Library.Mvc.Helpers;
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

        #region [ Login ]
        
        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {

            var response = Services.AuthService.Authenticate(new UserInputDto
            {
                User = new UserDto
                {
                    Username = model.Username,
                    Password = model.Password.HashMd5()
                }
            });

            if (response != null)
            {


                #region [ OWIN ]

                // OWIN Auth
                var claims = new ClaimsIdentity(new[] {
                        new Claim("Name", response.Name),
                        new Claim("Gender", response.Gender),
                        new Claim("Identity",Guid.NewGuid().ToString()),
                        new Claim("LastLoginDate",response.LastLoginDate.ToString()),
                        new Claim("Occupation",response.Occupation),
                        new Claim("UserId",response.UserId.ToString()),
                        new Claim("Role",response.Role),
                    },
                    "ApplicationCookie");

                var properties = new AuthenticationProperties();

                properties.IsPersistent = model.RememberMe;
                properties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1.0);
                
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
        
        
        #endregion

        #region [ Registeration ] 

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserRegistrationModel model)
        {
            // validation of the model
            bool isModelValid = Validate(model);


            if (isModelValid)
            {
                // create user input dto
                var uid = new UserInputDto
                {
                    User = new UserDto()
                    {
                        Name = model.Name,
                        Username = model.Username,
                        Occupation = model.Occupation,
                        Password = model.Password.HashMd5()
                    }
                };

                // send registeration request
                var response = Services.AuthService.Register(uid);

                if (response != null)
                {
                    return RedirectToAction("Index");
                }

                
            }

            return RedirectToAction("Register");
        }

        private bool Validate(UserRegistrationModel model)
        {
            return !String.IsNullOrEmpty(model.Username) || !String.IsNullOrEmpty(model.Password) ||
                   !String.IsNullOrEmpty(model.RetypePassword) || model.IsAgree;
        }

        #endregion
    }
}