using System;
using System.Configuration;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Book
{
    public class BookModuleRegisterar : IServiceApplication
    {
        public void RegisterServices(IWindsorContainer container)
        {
            string baseAddress = ConfigurationManager.AppSettings["BookServiceHost"];

            container.Register(
                Component.For<IBookService>().ImplementedBy<BookServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                    .AddEndpoints(WcfEndpoint.ForContract(typeof(IBookService)).BoundTo(new WSHttpBinding()
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
                            new Uri(baseAddress + "books"),
                        })).LifestylePerWcfOperation());
        }
    }
}
