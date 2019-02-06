using Library.Business.Services.Authantication.Dtos;
using Library.Business.Services.Authentication;
using Library.Data.Entities;
using Library.Data.Roles.Repositories;
using Library.Data.Users.Repositories;
using Moq;
using Xunit;

namespace Library.Services.Tests
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IRoleRepository> _roleRepository;
        private readonly AuthServiceApplication authServiceApplication;


        public AuthServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _roleRepository = new Mock<IRoleRepository>();

            authServiceApplication = new AuthServiceApplication(_userRepository.Object, _roleRepository.Object);
        }

        [Fact]
        public void WhenAuthenticate_IsSuccessful()
        {
            var euser = new EUser { Password = "p@ssw0rd" };
            var erole = new ERole { Name = "Administrator" };
            var request = new UserInputDto() {  User = new UserDto { Username = It.IsAny<string>(), Password = "p@ssw0rd" } };

            _userRepository.Setup(r => r.GetUserByNameAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(euser);
            _userRepository.Setup(r => r.UpdateEntity(It.IsAny<EUser>())).Returns(true);

            _roleRepository.Setup(r=>r.GetOne(It.IsAny<int>())).Returns(erole);

            var actual = authServiceApplication.Authenticate(request);

            Assert.Equal("Administrator",actual.Role);
        }

        [Fact]
        public void WhenAuthenticate_ReturnsNull()
        {
            var request = new UserInputDto() { User = new UserDto { Username = It.IsAny<string>(), Password = "p@ssw0rd" } };

            _userRepository.Setup(r => r.GetUserByNameAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(() => null);

            var actual = authServiceApplication.Authenticate(request);

            Assert.Null(actual);
        }

        [Fact]
        public void WhenRegister_ReturnsSucess()
        {
            var erole = new ERole { Name = "Administrator" };

            _userRepository.Setup(r=>r.CreateEntity(It.IsAny<EUser>())).Returns(new EUser() { Name = "demo", ERole = erole  });
            _roleRepository.Setup(r => r.GetOne(It.IsAny<int>())).Returns(erole);


            var actual = authServiceApplication.Register(new UserInputDto() { User = new UserDto { Name = "demo" } });

            Assert.Equal("demo", actual.Name);
            Assert.Equal("Administrator", actual.Role);
        }

        [Fact]
        public void WhenRegister_ReturnsNull()
        {
            var erole = new ERole { Name = "Administrator" };

            _userRepository.Setup(r => r.CreateEntity(It.IsAny<EUser>())).Returns(()=> null);
            _roleRepository.Setup(r => r.GetOne(It.IsAny<int>())).Returns(erole);


            var actual = authServiceApplication.Register(new UserInputDto() { User = new UserDto { Name = "demo" } });

            Assert.Null(actual);

        }
    }
}
