using Library.Business.Services.Authantication;
using Library.Business.Services.Book;
using Library.Business.Services.Integration;
using Library.Business.Services.Provider;
using Library.UI.Services.IoC;

namespace Library.UI.Services.Providers
{
    internal class ServiceProvider : IServiceProvider
    {
        public IBookService BookService
        {
            get { return IocManager.Container.Resolve<IBookService>(); }
        }

        public IAuthenticationService AuthenticationService
        {
            get { return IocManager.Container.Resolve<IAuthenticationService>();}

        }

        public IIntegrationService IntegrationService
        {
            get
            {
                return IocManager.Container.Resolve<IIntegrationService>();
            }
        }

        public IItemProvider ItemsProvider
        {
            get
            {
                return IocManager.Container.Resolve<IItemProvider>();
            }
        }
    }


}
