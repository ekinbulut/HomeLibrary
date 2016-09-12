using System.ServiceModel;
using Library.Business.Services.Authentication.Dtos;

namespace Library.Business.Services.Authentication
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
