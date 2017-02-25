using Library.UI.Services.Providers;

namespace Library.UI.Services.Controller
{
    public abstract class BaseController : IBaseController
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseController(IServiceProvider serviceProvider)
        {
           _serviceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }
    }
}
