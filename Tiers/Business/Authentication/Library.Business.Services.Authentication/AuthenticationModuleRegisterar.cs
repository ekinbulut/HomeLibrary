using System;
using System.ServiceModel;
using Castle.Core.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Authantication;
using Library.Business.Services.Helper;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Authentication
{
    public class AuthenticationModuleRegisterar : IServiceApplication
    {
        private readonly ILogger _logger;

        public AuthenticationModuleRegisterar(ILogger logger)
        {
            _logger = logger;
        }

        public void RegisterServices(IWindsorContainer container)
        {
            var ipaddress = IpFinder.GetLocalIpAddress();

            string baseAddress = $"http://{ipaddress}:8095/services/";

            container.Register(
                Component.For<IAuthenticationService>().ImplementedBy<AuthServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IAuthenticationService)).BoundTo(new WSHttpBinding
                            {
                                //PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new WSHttpSecurity { Mode = SecurityMode.None}

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri(baseAddress + "authentication"))).LifestylePerWcfOperation());

            _logger.Info($"Server endpoint on : {baseAddress}authentication");
        }
    }
}
