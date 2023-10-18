using TDDApplication3.DataAccessLayer.Models;

namespace TDDApplication3.DataAccessLayer.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User CreateUser(User user);
    }
}
