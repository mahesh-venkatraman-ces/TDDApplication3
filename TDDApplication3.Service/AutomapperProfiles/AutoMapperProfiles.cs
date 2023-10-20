using AutoMapper;
using TDDApplication3.DataAccessLayer.Models;
using TDDApplication3.DTO.DTOs;

namespace TDDApplication3.Service.AutomapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDTO>().ReverseMap();
            }
        }
    }
}
