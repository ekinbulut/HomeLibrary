using System;
using System.Web.Mvc;
using Library.Mvc.AuthenticationServices;
using Library.Mvc.Controllers;
using Library.Mvc.Models;

namespace Library.Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        //LOGIN PAGE
        public override ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {

            var output = Services.AuthServiceClient.Authenticate(new UserInputDto()
            {
                User = new UserDto()
                {
                    Username = model.Username,
                    Password = model.Password
                }
            });

            if (output != null)
            {

                Usermodel = new UserModel();
                Usermodel.Identity = Guid.NewGuid();
                Usermodel.Name = output.Name;
                Usermodel.LastLoginDate = output.LastLoginDate;
                Usermodel.Gender = output.Gender;
                Usermodel.Occupation = output.Occupation;

                Session.Add("Information",Usermodel);
                Session.Timeout = 5;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            if (Session["Information"] != null)
            {
                Session.Clear();
            }

            return RedirectToAction("Index", "Authentication");
        }
    }
}