using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Name = "IntegrationService",Namespace = "com.sense.business.Services")]
    public interface IIntegrationService
    {
        [OperationContract]
        bool Import(IntegrationInputDto input);

        [OperationContract]
        bool CreateAuthor(AuthorInputDto input);

        [OperationContract]
        bool CreatePublisher(PublisherInputDto input);
    }
}
