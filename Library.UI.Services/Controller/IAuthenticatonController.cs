using Library.UI.Services.Model;

namespace Library.UI.Services.Controller
{
    public interface IAuthenticatonController
    {
        UserModel Login(string username, string password);
    }
}