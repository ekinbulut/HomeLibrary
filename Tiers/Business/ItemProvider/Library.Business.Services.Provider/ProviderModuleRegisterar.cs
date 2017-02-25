using System;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Helper;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Provider
{
    public class ProviderModuleRegisterar : IServiceApplication

    {
        /// <summary>
        /// Registers the wcf services.
        /// </summary>
        /// <param name="container">The container.</param>
        public void RegisterServices(IWindsorContainer container)
        {
            //string baseAddress = ConfigurationManager.AppSettings["ProviderServiceHost"];
            var ipaddress = IpFinder.GetLocalIpAddress();

            string baseAddress = $"http://{ipaddress}:8098/services/";

            container.Register(
                Component.For<IItemProvider>().ImplementedBy<ItemProviderServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IItemProvider)).BoundTo(new WSHttpBinding
                            {
                                //PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new WSHttpSecurity { Mode = SecurityMode.None }

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri(baseAddress + "provider"))).LifestylePerWcfOperation());

        }
    }
}
