using Castle.Windsor;

namespace Library.UI.Services.Applications
{
    internal interface IServiceRegisterar
    {
        void RegisterServices(IWindsorContainer container);
        void RegisterComponents(IWindsorContainer container);
    }
}