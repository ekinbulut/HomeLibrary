using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Name = "IntegrationService",Namespace = "com.sense.business.Services")]
    public interface IIntegrationService
    {
        /// <summary>
        /// Imports the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [OperationContract]
        bool Import(IntegrationInputDto input);

        /// <summary>
        /// Creates the author.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [OperationContract]
        bool CreateAuthor(AuthorInputDto input);

        /// <summary>
        /// Creates the publisher.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [OperationContract]
        bool CreatePublisher(PublisherInputDto input);
    }
}
