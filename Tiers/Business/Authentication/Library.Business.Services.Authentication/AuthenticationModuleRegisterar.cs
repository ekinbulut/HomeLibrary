﻿using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Authentication
{
    public class AuthenticationModuleRegisterar : IServiceApplication
    {
        public void RegisterServices(IWindsorContainer container)
        {
            string baseAddress = ConfigurationManager.AppSettings["AuthHost"];

            container.Register(
                Component.For<IAuthenticationService>().ImplementedBy<AuthServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof (IAuthenticationService)).BoundTo(new NetTcpBinding()
                            {
                                PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new NetTcpSecurity() {Mode = SecurityMode.None}

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri[]
                        {
                            new Uri(baseAddress + "authentication"),
                        })).LifestylePerWcfOperation());
        }
    }
}
