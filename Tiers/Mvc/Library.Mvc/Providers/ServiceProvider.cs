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
        /// The _book service client
        /// </summary>
        private IBookService _bookServiceClient;
        /// <summary>
        /// The _integration service client
        /// </summary>
        private IIntegrationService _integrationServiceClient;
        /// <summary>
        /// The _item provider service client
        /// </summary>
        private IItemProvider _itemProviderServiceClient;

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
                return _bookServiceClient = IoCManager.Container.Resolve<IBookService>();  
            }
        }

        /// <summary>
        /// Gets the authentication service client.
        /// </summary>
        /// <value>
        /// The authentication service client.
        /// </value>
        //public AuthServiceClient AuthServiceClient
        //{
        //    get
        //    {
        //        return new AuthServiceClient();
        //    }
        //}

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
                
                return _itemProviderServiceClient = IoCManager.Container.Resolve<IItemProvider>();
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
                _integrationServiceClient = IoCManager.Container.Resolve<IIntegrationService>();
                
                return _integrationServiceClient;
            }
        }
    }
}
