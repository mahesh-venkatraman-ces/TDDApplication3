using Moq;
using TDDApplication3.API.Controllers;
using TDDApplication3.DataAccessLayer.Models;
using TDDApplication3.DTO.DTOs;
using TDDApplication3.Service.Interface;

namespace TDDApplication3.UnitTest.Systems.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Fixture _fixture;
        private readonly UserController _controller;
        public UserControllerTests()
        {
            _fixture = new Fixture();
            _userServiceMock = new Mock<IUserService>();
            _controller = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public void GetUser_WhenCalled_Return200StatusCode()
        {
            //Arrange

            var data = _fixture.Create<List<UserDTO>>();
            _userServiceMock
                .Setup(service => service.GetUserList())
                .Returns(data);

            // Act

            var result = (OkObjectResult)_controller.GetUsers();

            // Assert

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(data, result.Value);
            _userServiceMock.Verify(s => s.GetUserList(), Times.Once);

        }

        [Fact]
        public void GetUser_WhenCalled_ReturnNoContent()
        {
            var data = _fixture.CreateMany<UserDTO>(0).ToList();
            _userServiceMock
                .Setup(service => service.GetUserList())
                .Returns(data);

            // Act

            var result = (NoContentResult)_controller.GetUsers();

            // Assert

            Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, result.StatusCode);

        }
    }
}
