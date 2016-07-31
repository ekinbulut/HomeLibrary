using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Namespace = "com.sense.services.Services", Name = "AuthService")]
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [OperationContract]
        UserOutputDto Authenticate(UserInputDto input);
    }
}
