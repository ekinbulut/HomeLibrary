using System.Configuration;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Library.Business.Services.Authantication;
using Library.Business.Services.Book;
using Library.Business.Services.Integration;
using Library.Business.Services.Provider;

namespace Library.Mvc.Base
{
    public class ServiceRegisterar
    {
        public void RegisterServices()
        {
            int maxRecievedSize = int.Parse(ConfigurationManager.AppSettings["MaxReceivedMessageSize"]);
            string authHost = ConfigurationManager.AppSettings["AuthHost"];
            string bookServiceHost = ConfigurationManager.AppSettings["BookServiceHost"];
            string integrationServiceHost = ConfigurationManager.AppSettings["IntegrationServiceHost"];
            string providerServiceHost = ConfigurationManager.AppSettings["ProviderServiceHost"];


            IoCManager.Container.Register(
                Component.For<IAuthenticationService>()
                .AsWcfClient(new DefaultClientModel()
                {
                    Endpoint = WcfEndpoint.BoundTo(new WSHttpBinding()
                    {
                        Security = new WSHttpSecurity() {  Mode = SecurityMode.None }

                    }).At(authHost+"authentication")
                })
            );

            IoCManager.Container.Register(
                Component.For<IBookService>()
                .AsWcfClient(new DefaultClientModel()
                {
                    Endpoint = WcfEndpoint.BoundTo(new WSHttpBinding()
                    {
                        MaxReceivedMessageSize = maxRecievedSize,
                        Security = new WSHttpSecurity() { Mode = SecurityMode.None }

                    }).At(bookServiceHost + "books")
                })
            );

            IoCManager.Container.Register(
                Component.For<IIntegrationService>()
                .AsWcfClient(new DefaultClientModel()
                {
                    Endpoint = WcfEndpoint.BoundTo(new WSHttpBinding()
                    {
                        MaxReceivedMessageSize = maxRecievedSize,
                        Security = new WSHttpSecurity() { Mode = SecurityMode.None }

                    }).At(integrationServiceHost + "integration")
                })
            );

            IoCManager.Container.Register(
                Component.For<IItemProvider>()
                .AsWcfClient(new DefaultClientModel()
                {
                    Endpoint = WcfEndpoint.BoundTo(new WSHttpBinding()
                    {
                        MaxReceivedMessageSize = maxRecievedSize,
                        Security = new WSHttpSecurity() { Mode = SecurityMode.None }

                    }).At(providerServiceHost + "provider")
                })
            );
        }
    }
}
