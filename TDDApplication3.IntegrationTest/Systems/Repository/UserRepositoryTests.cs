﻿using TDDApplication3.DataAccessLayer;
using TDDApplication3.DataAccessLayer.Models;

namespace TDDApplication3.IntegrationTest.Systems.Repository
{
    public class UserRepositoryTests 
    {
        [Fact]
        public void GetUsers_WhenCalled_ReturnsUserLists()
        {
            // Arrange

            var sut = new UserRepository();

            // Act

            var user = sut.GetUsers();

            // Assert

            user.Should().NotBeNull();
            Assert.IsType<List<User>>(user);

        }

        [Fact]
        public async Task CreateUser_WhenCalled_ReturnsId()
        {
            // Arrange

            var fixture = new Fixture();
            var inputData = fixture.Build<User>()
                .Without(p => p.UserId)
                .Create();
            var sut = new UserRepository();

            // Act

            var result = sut.CreateUser(inputData);

            // Assert

            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }
    }
}
