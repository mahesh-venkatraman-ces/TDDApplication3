using TDDApplication3.DataAccessLayer.Models;
using TDDApplication3.DTO.DTOs;

namespace TDDApplication3.Service.Interface
{
    public interface IUserService
    {
        List<UserDTO> GetUserList();
        UserDTO CreateUser(UserDTO user);
    }
}
