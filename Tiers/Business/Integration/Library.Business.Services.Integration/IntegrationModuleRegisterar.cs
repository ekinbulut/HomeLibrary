using System;
using System.Configuration;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Integration.Parser;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Integration
{
    public class IntegrationModuleRegisterar : IServiceApplication
    {
        public void RegisterServices(IWindsorContainer container)
        {
            container.Register(
                Component.For<IParserApplication>().ImplementedBy<ExcelParserApplication>().LifestyleSingleton());

            string baseAddress = ConfigurationManager.AppSettings["IntegrationServiceHost"];

            container.Register(
                Component.For<IIntegrationService>().ImplementedBy<IntegrationServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IIntegrationService)).BoundTo(new WSHttpBinding()
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
                            new Uri(baseAddress + "integration"),
                        })).LifestylePerWcfOperation());

        }
    }
}
