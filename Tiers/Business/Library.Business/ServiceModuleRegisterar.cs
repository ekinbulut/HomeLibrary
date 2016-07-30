using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Applications;
using Library.Business.Parser;
using Library.Business.Services;
using SenseFramework.Services.Integrations;

namespace Library.Business
{
    public class ServiceModuleRegisterar : IServiceApplication

    {
        public void RegisterServices(IWindsorContainer container)
        {
            container.Register(
                Component.For<IParserApplication>().ImplementedBy<ExcelParserApplication>().LifestyleSingleton());

            container.AddFacility<WcfFacility>(f =>
            {
                f.Services.AspNetCompatibility = AspNetCompatibilityRequirementsMode.Allowed;
            });

            string baseAddress = ConfigurationManager.AppSettings["Host"];

            ServiceDebugBehavior returnFaults = new ServiceDebugBehavior
            {
                IncludeExceptionDetailInFaults = true,
                HttpHelpPageEnabled = true,
            };

            container.Register(
                Component.For<IServiceBehavior>().Instance(returnFaults));

            container.Register(
                Component.For<IBookService>().ImplementedBy<BookServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                    .AddEndpoints(WcfEndpoint.ForContract(typeof(IBookService)).BoundTo(new NetTcpBinding()
                    {
                        PortSharingEnabled = true,
                        MaxReceivedMessageSize = int.MaxValue,
                        ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                        CloseTimeout = new TimeSpan(0, 0, 0, 60, 0)
                    }))
                    .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "books"),
                        })).LifestylePerWcfOperation());

            container.Register(
                Component.For<IAuthanticationService>().ImplementedBy<AuthServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(WcfEndpoint.ForContract(typeof(IAuthanticationService)).BoundTo(new NetTcpBinding()
                        {
                            PortSharingEnabled = true,
                            MaxReceivedMessageSize = int.MaxValue,
                            ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                            CloseTimeout = new TimeSpan(0, 0, 0, 60, 0)
                        }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "authentication"),
                        })).LifestylePerWcfOperation());

            container.Register(
                Component.For<IItemProvider>().ImplementedBy<ItemProviderServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IItemProvider)).BoundTo(new NetTcpBinding()
                            {
                                PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0)
                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "provider"),
                        })).LifestylePerWcfOperation());

            container.Register(
                Component.For<IIntegrationService>().ImplementedBy<IntegrationServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IIntegrationService)).BoundTo(new NetTcpBinding()
                            {
                                PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0)
                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "integration"),
                        })).LifestylePerWcfOperation());
        }
    }
}
