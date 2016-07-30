using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Namespace = "com.sense.services.Services", Name = "AuthService")]
    public interface IAuthanticationService
    {
        [OperationContract]
        UserOutputDto Authanticate(UserInputDto input);
    }
}
