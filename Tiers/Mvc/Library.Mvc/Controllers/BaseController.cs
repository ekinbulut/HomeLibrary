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

        /// <summary>
        /// 
        /// </summary>
        public IOwinContext GetAuthContext => _authContext ?? (_authContext = Request.GetOwinContext());

        /// <summary>
        /// 
        /// </summary>
        public UserModel CurrentUserModel
        {
            get
            {
                if (_usermodel == null)
                {
                    _usermodel = GetUserModel();
                }

                return _usermodel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private UserModel GetUserModel()
        {
            var usermodel = new UserModel();

            var ctx = GetAuthContext;

            var identity = ctx.Authentication.User;

            var name = identity.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            var gender = identity.Claims.FirstOrDefault(c => c.Type == "Gender").Value;
            var Identity = identity.Claims.FirstOrDefault(c => c.Type == "Identity").Value;
            var LastLoginDate = identity.Claims.FirstOrDefault(c => c.Type == "LastLoginDate").Value;
            var Occupation = identity.Claims.FirstOrDefault(c => c.Type == "Occupation").Value;
            var Role = identity.Claims.FirstOrDefault(c => c.Type == "Role").Value;
            var UserId = identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

            usermodel.Name = name;
            usermodel.Gender = gender;
            usermodel.Identity = Guid.Parse(Identity);
            usermodel.LastLoginDate = DateTime.Parse(LastLoginDate);
            usermodel.Occupation = Occupation;
            usermodel.UserId = int.Parse(UserId);
            usermodel.Role = Role;

            return usermodel;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ActionResult Index();

    }
}
