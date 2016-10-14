using Castle.Facilities.WcfIntegration;
using Castle.Windsor;

namespace Library.Mvc.Base
{
    public static class IoCManager
    {
        private static IWindsorContainer container;

        public static IWindsorContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new WindsorContainer();
                    container.Kernel.AddFacility<WcfFacility>();

                    return container;
                }

                return container;
            }
        }
    }
}
