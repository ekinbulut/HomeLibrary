using Castle.Facilities.WcfIntegration;
using Castle.Windsor;

namespace Library.UI.Services.IoC
{
    internal static class IocManager
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new WindsorContainer();
                    _container.Kernel.AddFacility<WcfFacility>();

                    return _container;
                }

                return _container;
            }
        }
    }
}
