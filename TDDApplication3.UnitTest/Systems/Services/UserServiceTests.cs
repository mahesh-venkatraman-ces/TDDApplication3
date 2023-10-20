using AutoMapper;
using TDDApplication3.DataAccessLayer.Interface;
using TDDApplication3.DataAccessLayer.Models;
using TDDApplication3.DTO.DTOs;
using TDDApplication3.Service;
using TDDApplication3.Service.AutomapperProfiles;
using TDDApplication3.Service.Interface;

namespace TDDApplication3.UnitTest.Systems.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userDbServiceMock;
        private readonly Fixture _fixture;
        private readonly IUserService _repository;
        private readonly IMapper _mapper;
        public UserServiceTests()
        {
            _fixture = new Fixture();
            var myProfile = new AutoMapperProfiles.AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
            _userDbServiceMock = new Mock<IUserRepository>();
            _repository = new UserService(_userDbServiceMock.Object, _mapper);
        }

        [Fact]
        public async Task GetUsersDB_WhenCalled_Returns_UsersList()
        {
            // Arrange

            var data = _fixture.Create<List<User>>();
            _userDbServiceMock
                .Setup(service => service.GetUsers())
                .Returns(data);

            // Act

            var result = _repository.GetUserList();

            // Assert

            Assert.Equal(data.ToString(), result.ToString());
            Assert.IsType<List<User>>(result);
            _userDbServiceMock
                .Verify(service => service.GetUsers(), Times.Once());
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnId()
        {
            // Arrange

            var returnData = _fixture.Create<User>();
            var inputData = _fixture.Create<UserDTO>();
            _userDbServiceMock
                .Setup(service => service.CreateUser(returnData))
                .Returns(returnData);

            // Act

            var result = _repository.CreateUser(inputData);

            // Assert

            Assert.IsType<string>(result);
            Assert.Equal(returnData.ToString(), result.ToString());
            _userDbServiceMock
                .Verify(service => service.CreateUser(returnData), Times.Once());

        }
    }
}
