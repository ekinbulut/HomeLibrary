/*
 * Author : Ekin Bulut
 * ServiceProvider is for providing related services to related Controllers.
*/

using System.ServiceModel;
using Library.Mvc.AuthenticationServices;
using Library.Mvc.BookServices;
using Library.Mvc.IntegrationServices;
using Library.Mvc.ItemProviderServices;


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
        private BookServiceClient _bookServiceClient;
        /// <summary>
        /// The _integration service client
        /// </summary>
        private IntegrationServiceClient _integrationServiceClient;
        /// <summary>
        /// The _item provider service client
        /// </summary>
        private ItemProviderServiceClient _itemProviderServiceClient;

        /// <summary>
        /// Gets the book service client.
        /// </summary>
        /// <value>
        /// The book service client.
        /// </value>
        public BookServiceClient BookServiceClient
        {
            get
            {
                if (_bookServiceClient != null)
                {
                    if (_bookServiceClient.State == CommunicationState.Faulted)
                    {
                        return _bookServiceClient = new BookServiceClient();
                    }

                    return _bookServiceClient;
                }

               return _bookServiceClient = new BookServiceClient();  
            }
        }

        /// <summary>
        /// Gets the authentication service client.
        /// </summary>
        /// <value>
        /// The authentication service client.
        /// </value>
        public AuthServiceClient AuthServiceClient
        {
            get
            {
                return new AuthServiceClient();
            }
        }

        /// <summary>
        /// Gets the item provider service client.
        /// </summary>
        /// <value>
        /// The item provider service client.
        /// </value>
        public ItemProviderServiceClient ItemProviderServiceClient
        {
            get
            {
                if (_itemProviderServiceClient != null)
                {
                    if (_itemProviderServiceClient.State == CommunicationState.Faulted)
                    {
                        return _itemProviderServiceClient = new ItemProviderServiceClient();
                    }
                    return _itemProviderServiceClient;
                }
                return _itemProviderServiceClient = new ItemProviderServiceClient();
            }
        }

        /// <summary>
        /// Gets the integration service client.
        /// </summary>
        /// <value>
        /// The integration service client.
        /// </value>
        public IntegrationServiceClient IntegrationServiceClient
        {
            get
            {
                if (_integrationServiceClient != null)
                {
                    if (_integrationServiceClient.State == CommunicationState.Faulted)
                    {
                        return _integrationServiceClient = new IntegrationServiceClient();
                    }

                    return _integrationServiceClient;
                }

                _integrationServiceClient = new IntegrationServiceClient();
                
                return _integrationServiceClient;
            }
        }
    }
}
