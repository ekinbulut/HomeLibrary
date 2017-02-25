using System.ServiceModel;

namespace Library.Business.Services.Integration
{
    [ServiceContract(Name = "IntegrationService",Namespace = "com.sense.business.Services")]
    public interface IIntegrationService : IImport , ICreationMethods, IStreamServices
    {

    }
}
