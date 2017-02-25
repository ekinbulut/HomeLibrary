using System.ServiceModel;
using Library.Business.Services.Integration.Dtos;

namespace Library.Business.Services.Integration
{
    [ServiceContract(Name = "IntegrationService", Namespace = "com.sense.business.Services")]
    public interface IStreamServices
    {
        [OperationContract]
        bool SendFile(IntegrationInputDto input);
    }
}