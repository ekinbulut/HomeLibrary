using Library.Business.Services.Integration.Dtos;
using System.ServiceModel;

namespace Library.Business.Services.Integration
{
    [ServiceContract(Name = "IntegrationService", Namespace = "com.sense.business.Services")]
    public interface IImport
    {
        [OperationContract]
        bool Import(ImportInputDto input);
    }
}