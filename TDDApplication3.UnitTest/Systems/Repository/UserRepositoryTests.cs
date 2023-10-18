using TDDApplication3.DataAccessLayer.Interface;
using TDDApplication3.DataAccessLayer.Models;

namespace TDDApplication3.UnitTest.Systems.Repository
{
    public class UserRepositoryTests
    {
        private readonly Fixture _fixture;
        private readonly IUserRepository _userrepository;

        public UserRepositoryTests()
        {
            _fixture = new Fixture();
        }
        [Fact]
        public void GetUserAsync_WhenCalled_ReturnUserList()
        {
            // Arrange

            var data = _fixture.Create<List<User>>();

            // Act

            var result = _userrepository.GetUsers();

            // Assert

            Assert.Equal(data, result);
            Assert.IsType<List<User>>(result);
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnIdString()
        {
            // Arrange

            var returnData = _fixture.Create<User>();
            var inputData = _fixture.Create<User>();

            // Act

            var result = _userrepository.CreateUser(inputData);

            // Assert

            Assert.IsType<string>(result);
            Assert.Equal(returnData, result);
        }
    }
}
