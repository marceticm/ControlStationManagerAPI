using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;

namespace ControlStationManagerAPI.MapProfiles
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<User, UserForDisplayDto>();
        }
    }
}
