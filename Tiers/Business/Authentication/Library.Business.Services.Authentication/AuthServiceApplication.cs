using System;
using Library.Business.Services.Authantication;
using Library.Business.Services.Authantication.Dtos;
using Library.Data.Users.Repositories;
using Library.Data.Roles.Repositories;
using Library.Data.Entities;

namespace Library.Business.Services.Authentication
{
    public class AuthServiceApplication : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthServiceApplication(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Authenticates the specified input.
        /// </summary>
        /// <param name="input">UserInputDto contains user information.</param>
        /// <returns>UserOutputDto</returns>
        public UserOutputDto Authenticate(UserInputDto input)
        {
            var user = _userRepository.GetUserByNameAndPassword(input.User.Username,input.User.Password);

            if (user != null)
            {
                if (user.Password.Equals(input.User.Password))
                {
                    user.LastLoginDate = DateTime.Now;
                    var result = _userRepository.UpdateEntity(user);

                    if (!result) return null;


                    var role = _roleRepository.GetOne(user.RoleId);

                    return new UserOutputDto
                    {
                        UserId = user.Id,
                        Name = user.Name,
                        Gender =  Enum.GetName(typeof(Gender),user.Gender),
                        Occupation = user.Occupation,
                        LastLoginDate = user.CreatedDateTime,
                        Role = role.Name
                    };
                }
            }

            return null;
        }

        public UserOutputDto Register(UserInputDto input)
        {
            // create user record
            var record = new EUser
            {
                Gender = Gender.Male,
                Occupation = input.User.Occupation,
                UserName = input.User.Username,
                Password = input.User.Password,
                IsActive = true,
                Name = input.User.Name,

                // set role
                ERole = _roleRepository.GetOne(2)
            };

            // create record
            var user = _userRepository.CreateEntity(record);

            if (user != null)
            {
                return new UserOutputDto
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Gender = Enum.GetName(typeof(Gender), user.Gender),
                    Occupation = user.Occupation,
                    LastLoginDate = user.CreatedDateTime,
                    Role = user.ERole.Name
                };
            }

            return null;
        }

    }
}
