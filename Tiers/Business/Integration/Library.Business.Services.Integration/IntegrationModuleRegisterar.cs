using System;
using System.ServiceModel;
using Castle.Core.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Helper;
using Library.Business.Services.Integration.Model;
using Library.Business.Services.Integration.Parser;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Integration
{
    public class IntegrationModuleRegisterar : IServiceApplication
    {
        private ILogger _logger;

        public IntegrationModuleRegisterar(ILogger logger)
        {
            _logger = logger;
        }

        public void RegisterServices(IWindsorContainer container)
        {
            container.Register(
                Component.For<IFileReciever>().ImplementedBy<FileReciever>().LifestyleTransient());

            container.Register(
                Component.For<IParserApplication>().ImplementedBy<ExcelParserApplication>().LifestyleSingleton());

            container.Register(
                Component.For<IImporter>().ImplementedBy<Importer>().LifestyleSingleton());

            //string baseAddress = ConfigurationManager.AppSettings["IntegrationServiceHost"];
            var ipaddress = IpFinder.GetLocalIpAddress();

            string baseAddress = $"http://{ipaddress}:8096/services/";


            container.Register(
                Component.For<IIntegrationService>().ImplementedBy<IntegrationServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IIntegrationService)).BoundTo(new WSHttpBinding
                            {
                                //PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new WSHttpSecurity { Mode = SecurityMode.None }

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri(baseAddress + "integration"))).LifestylePerWcfOperation());

            _logger.Info($"Server endpoint on : {baseAddress}integration");


        }
    }
}
