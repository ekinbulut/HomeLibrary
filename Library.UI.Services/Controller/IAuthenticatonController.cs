using Library.UI.Services.Model;

namespace Library.UI.Services.Controller
{
    public interface IAuthenticatonController
    {
        UserModelView Login(string username, string password);
    }
}