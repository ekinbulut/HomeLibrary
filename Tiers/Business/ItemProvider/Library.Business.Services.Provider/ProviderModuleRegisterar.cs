﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using Castle.Core.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Library.Business.Services.Helper;
using SenseFramework.Services.Integrations;

namespace Library.Business.Services.Provider
{

    [ExcludeFromCodeCoverage]
    public class ProviderModuleRegisterar : IServiceApplication

    {
        private readonly ILogger _logger;

        public ProviderModuleRegisterar(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Registers the wcf services.
        /// </summary>
        /// <param name="container">The container.</param>
        public void RegisterServices(IWindsorContainer container)
        {
            var ipaddress = IpFinder.GetLocalIpAddress();

            string baseAddress = $"http://{ipaddress}:8098/services/";

            container.Register(
                Component.For<IItemProvider>().ImplementedBy<ItemProviderServiceApplication>()
                    .AsWcfService(new DefaultServiceModel()
                        .AddEndpoints(
                            WcfEndpoint.ForContract(typeof(IItemProvider)).BoundTo(new WSHttpBinding
                            {
                                //PortSharingEnabled = true,
                                MaxReceivedMessageSize = int.MaxValue,
                                ReceiveTimeout = new TimeSpan(0, 0, 2, 0, 0),
                                CloseTimeout = new TimeSpan(0, 0, 0, 60, 0),
                                Security = new WSHttpSecurity { Mode = SecurityMode.None }

                            }))
                        .PublishMetadata(c => c.EnableHttpGet())
                        .AddBaseAddresses(new Uri(baseAddress + "provider"))).LifestylePerWcfOperation());

            _logger.Info($"Server endpoint on : {baseAddress}provider");

        }
    }
}
