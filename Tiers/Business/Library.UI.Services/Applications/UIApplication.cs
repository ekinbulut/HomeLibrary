using Library.UI.Services.Controller;
using Library.UI.Services.IoC;
using Library.UI.Services.Providers;

namespace Library.UI.Services.Applications
{
    public static class UIApplication
    {
        private static IServiceRegisterar _services;

        static UIApplication()
        {
            _services = new ServiceRegisterar();
        }

        public static void StartApplication()
        {
            _services.RegisterServices(IocManager.Container);
            _services.RegisterComponents(IocManager.Container);
        }

        internal static IServiceProvider Services
        {
            get { return IocManager.Container.Resolve<IServiceProvider>(); }
        }

        public static IAuthenticatonController AuthenticationController
        {
            get { return IocManager.Container.Resolve<IAuthenticatonController>(); }
        }

        public static ILibraryController LibraryController
        {
            get { return IocManager.Container.Resolve<ILibraryController>(); }
        }
    }
}
