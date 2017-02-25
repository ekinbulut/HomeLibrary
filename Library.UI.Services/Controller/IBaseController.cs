using Library.UI.Services.Providers;

namespace Library.UI.Services.Controller
{
    public interface IBaseController
    {
        IServiceProvider ServiceProvider { get; }
    }
}