using AutoMapper;
using TDDApplication3.DataAccessLayer.Interface;
using TDDApplication3.DataAccessLayer.Models;
using TDDApplication3.DTO.DTOs;
using TDDApplication3.Service.Interface;

namespace TDDApplication3.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userrepository, IMapper mapper)
        {
            _userrepository = userrepository;
            _mapper = mapper;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            var input = _mapper.Map<User>(user);
            var data = _userrepository.CreateUser(input);
            var result = _mapper.Map<UserDTO>(data);
            return result;
        }

        public List<UserDTO> GetUserList()
        {
            var data = _userrepository.GetUsers();
            var result =_mapper.Map<List<UserDTO>>(data);
            return result;
        }
    }
}
