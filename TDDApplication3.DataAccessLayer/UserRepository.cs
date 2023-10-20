using TDDApplication3.DataAccessLayer.Interface;
using TDDApplication3.DataAccessLayer.Models;

namespace TDDApplication3.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            
        }

        public User CreateUser(User user)
        {
            user.CreatedDateTime = DateTime.Now;
            //var data = _dbContext.CreteUserAsync(user);
            return user;
        }

        public List<User> GetUsers()
        {
            //var data = _dbContext.GetUsersAsync();
            var data = new List<User>()
            {
                new User
                {
                    CreatedDateTime = DateTime.Now,
                    Name = "Test",
                    Surname = "Test",
                    UserId = 1,
                    Username = "Test"
                }
            };
            return data;            
        }
    }
}
