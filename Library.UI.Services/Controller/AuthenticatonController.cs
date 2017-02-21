using System.Threading.Tasks;
using Library.Business.Services.Authantication.Dtos;
using Library.UI.Services.Model;
using Library.UI.Services.Providers;

namespace Library.UI.Services.Controller
{
    public class AuthenticatonController : BaseController, IAuthenticatonController
    {
        public UserModel Login(string username, string password)
        {
            UserOutputDto model = null;
            
            var task = Task.Run(() =>
            {
                model = ServiceProvider.AuthenticationService.Authenticate(new UserInputDto()
                {
                    User = new UserDto()
                    {
                        Username = username,
                        Password = password
                    }
                });
            });

            task.Wait();

            return model != null ? new UserModel()
            {
                Name = model.Name,
                Gender = model.Gender,
                LastLoginDate = model.LastLoginDate,
                Occupation = model.Occupation,
                UserId = model.UserId

            } : null;
        }

        public AuthenticatonController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
