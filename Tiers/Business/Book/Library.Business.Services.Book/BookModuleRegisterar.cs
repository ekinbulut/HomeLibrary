using System;
using System.ServiceModel;
using Castle.Core.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Helper;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Book
{
    public class BookModuleRegisterar : IServiceApplication
    {
        private ILogger _logger;

        public BookModuleRegisterar(ILogger logger)
        {
            _logger = logger;
        }

        public void RegisterServices(IWindsorContainer container)
        {
           // string baseAddress = ConfigurationManager.AppSettings["BookServiceHost"];
            var ipaddress = IpFinder.GetLocalIpAddress();

            string baseAddress = $"http://{ipaddress}:8097/services/";


            container.Register(
                Component.For<IBookService>().ImplementedBy<BookServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                    .AddEndpoints(WcfEndpoint.ForContract(typeof(IBookService)).BoundTo(new WSHttpBinding
                    {
                        //PortSharingEnabled = true,
                        MaxReceivedMessageSize = int.MaxValue,
                        ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                        CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                        Security = new WSHttpSecurity { Mode = SecurityMode.None }

                    }))
                    .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri(baseAddress + "books"))).LifestylePerWcfOperation());

            _logger.Info($"Server endpoint on : {baseAddress}books");

        }
    }
}
