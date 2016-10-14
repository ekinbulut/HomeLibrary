using System;
using System.Configuration;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Authantication;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Authentication
{
    public class AuthenticationModuleRegisterar : IServiceApplication
    {
        public void RegisterServices(IWindsorContainer container)
        {
            string baseAddress = ConfigurationManager.AppSettings["AuthHost"];

            //container.Register(
            //    Component.For<IAuthenticationService>().ImplementedBy<AuthServiceApplication>()
            //        .AsWcfService(new DefaultServiceModel()
            //            .AddEndpoints(
            //                WcfEndpoint.ForContract(typeof (IAuthenticationService)).BoundTo(new NetTcpBinding()
            //                {
            //                    PortSharingEnabled = true,
            //                    MaxReceivedMessageSize = int.MaxValue,
            //                    ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
            //                    CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
            //                    Security = new NetTcpSecurity() {Mode = SecurityMode.None}

            //                }))
            //            .PublishMetadata(c => c.EnableHttpGet())
            //            .AddBaseAddresses(new Uri[]
            //            {
            //                new Uri(baseAddress + "authentication"),
            //            })).LifestylePerWcfOperation());

            container.Register(
                Component.For<IAuthenticationService>().ImplementedBy<AuthServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IAuthenticationService)).BoundTo(new WSHttpBinding()
                            {
                                //PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new WSHttpSecurity() { Mode = SecurityMode.None}

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "authentication"),
                        })).LifestylePerWcfOperation());
        }
    }
}
