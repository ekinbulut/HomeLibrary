using System.ServiceModel;
using Library.Business.Services.Integration.Dtos;

namespace Library.Business.Services.Integration
{
    [ServiceContract(Name = "IntegrationService", Namespace = "com.sense.business.Services")]
    public interface ICreationMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperationContract]
        bool CreateAuthor(AuthorInputDto input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperationContract]
        bool CreatePublisher(PublisherInputDto input);

    }
}