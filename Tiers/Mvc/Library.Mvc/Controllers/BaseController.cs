using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Mvc.Models;
using Library.Mvc.Providers;
using Microsoft.Owin;

namespace Library.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ServiceProvider Services;
        private UserModel _usermodel;
        private IOwinContext _authContext;

        protected BaseController()
        {
            Services = new ServiceProvider();
            
        }


        public IOwinContext GetAuthContext => _authContext ?? (_authContext = Request.GetOwinContext());

        public UserModel CurrentUserModel
        {
            get
            {
                if (_usermodel == null)
                {
                    _usermodel = new UserModel();

                    var ctx = GetAuthContext;

                    var identity = ctx.Authentication.User;

                    var name = identity.Claims.FirstOrDefault(c => c.Type == "Name").Value;
                    var gender = identity.Claims.FirstOrDefault(c => c.Type == "Gender").Value;
                    var Identity = identity.Claims.FirstOrDefault(c => c.Type == "Identity").Value;
                    var LastLoginDate = identity.Claims.FirstOrDefault(c => c.Type == "LastLoginDate").Value;
                    var Occupation = identity.Claims.FirstOrDefault(c => c.Type == "Occupation").Value;
                    var UserId = identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

                    _usermodel.Name = name;
                    _usermodel.Gender = gender;

                    _usermodel.Identity = Guid.Parse(Identity);
                    _usermodel.LastLoginDate = DateTime.Parse(LastLoginDate);
                    _usermodel.Occupation = Occupation;
                    _usermodel.UserId = int.Parse(UserId);

                    return _usermodel;
                }

                return _usermodel;
            }
        }

        public abstract ActionResult Index();

    }
}
