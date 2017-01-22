using System.ServiceModel;
using Library.Business.Services.Authantication.Dtos;

namespace Library.Business.Services.Authantication
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
