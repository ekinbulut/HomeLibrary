using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
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
            string baseAddress = ConfigurationManager.AppSettings["ProviderServiceHost"];



            //container.Register(
            //    Component.For<IItemProvider>().ImplementedBy<ItemProviderServiceApplication>()
            //        .AsWcfService(new DefaultServiceModel()
            //            .AddEndpoints(
            //                WcfEndpoint.ForContract(typeof(IItemProvider)).BoundTo(new NetTcpBinding()
            //                {
            //                    PortSharingEnabled = true,
            //                    MaxReceivedMessageSize = int.MaxValue,
            //                    ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
            //                    CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
            //                    Security = new NetTcpSecurity() { Mode = SecurityMode.None }

            //                }))
            //            .PublishMetadata(c => c.EnableHttpGet())
            //            .AddBaseAddresses(new Uri[]
            //            {
            //                new Uri(baseAddress + "provider"),
            //            })).LifestylePerWcfOperation());


            container.Register(
                Component.For<IItemProvider>().ImplementedBy<ItemProviderServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IItemProvider)).BoundTo(new WSHttpBinding()
                            {
                                //PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new WSHttpSecurity() { Mode = SecurityMode.None }

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "provider"),
                        })).LifestylePerWcfOperation());

        }
    }
}
