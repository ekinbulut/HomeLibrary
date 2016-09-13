using System;
using Library.Business.Services.Authentication.Dtos;
using Library.Data.Athentication.Entities;
using Library.Data.Athentication.Repositories.Users;

namespace Library.Business.Services.Authentication
{
    public class AuthServiceApplication : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthServiceApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Authenticates the specified input.
        /// </summary>
        /// <param name="input">UserInputDto contains user information.</param>
        /// <returns>UserOutputDto</returns>
        public UserOutputDto Authenticate(UserInputDto input)
        {
            var user = _userRepository.GetUserByName(input.User.Username);

            if (user != null)
            {
                if (user.Password.Equals(input.User.Password))
                {
                    user.LastLoginDate = DateTime.Now;
                    var result = _userRepository.UpdateEntity(user.Id, user);

                    if (!result) return null;
                    
                    return new UserOutputDto()
                    {
                        Name = user.Name,
                        Gender =  Enum.GetName(typeof(Gender),user.Gender),
                        Occupation = user.Occupation,
                        LastLoginDate = user.CreatedDateTime
                    };
                }
            }

            return null;
        }
    }
}
