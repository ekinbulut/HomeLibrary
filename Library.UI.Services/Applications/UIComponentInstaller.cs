using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Library.UI.Services.Controller;
using Library.UI.Services.Providers;

namespace Library.UI.Services.Applications
{
    internal class UIComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Providers.IServiceProvider > ().ImplementedBy<ServiceProvider>());

            container.Register(
                Classes.FromThisAssembly()
                .BasedOn<IBaseController>()
                .WithServiceDefaultInterfaces()
                .LifestyleSingleton());
        }
    }
}