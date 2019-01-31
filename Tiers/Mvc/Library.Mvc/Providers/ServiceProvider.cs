/*
 * Author : Ekin Bulut
 * ServiceProvider is for providing related services to related Controllers.
*/


using Library.Business.Services.Authantication;
using Library.Business.Services.Book;
using Library.Business.Services.Integration;
using Library.Business.Services.Provider;
using Library.Mvc.IoC;

namespace Library.Mvc.Providers
{
    /// <summary>
    /// Service Provider Class
    /// </summary>
    public class ServiceProvider
    {


        /// <summary>
        /// Gets the book service client.
        /// </summary>
        /// <value>
        /// The book service client.
        /// </value>
        public IBookService BookServiceClient
        {
            get
            {
                return IoCManager.Container.Resolve<IBookService>();  
            }
        }


        public IAuthenticationService AuthService
        {
            get { return IoCManager.Container.Resolve<IAuthenticationService>(); }
        }

        /// <summary>
        /// Gets the item provider service client.
        /// </summary>
        /// <value>
        /// The item provider service client.
        /// </value>
        public IItemProvider ItemProviderServiceClient
        {
            get
            {
                
                return IoCManager.Container.Resolve<IItemProvider>();
            }
        }

        /// <summary>
        /// Gets the integration service client.
        /// </summary>
        /// <value>
        /// The integration service client.
        /// </value>
        public IIntegrationService IntegrationServiceClient
        {
            get
            {
                return IoCManager.Container.Resolve<IIntegrationService>();
            }
        }
    }
}
