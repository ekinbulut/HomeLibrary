using System;
using System.Web.Mvc;
using Library.Business.Services.Authantication.Dtos;
using Library.Mvc.Models;
using Library.Mvc.Providers;

namespace Library.Web.Controllers
{
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
            
            var output = Services.AuthService.Authenticate(new UserInputDto()
            {
                User = new UserDto()
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

                Session.Add("Information",Usermodel);
                Session.Timeout = 5;

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

            return RedirectToAction("Index", "Authentication");
        }
    }
}