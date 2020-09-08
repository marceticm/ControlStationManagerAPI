using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;

namespace ControlStationManagerAPI.MapProfiles
{
    public class StationItemMapProfile : Profile
    {
        public StationItemMapProfile()
        {
            CreateMap<StationItem, ControlStationItemDto>()
                .ForMember(dest => dest.ControlStationName, opt => opt.MapFrom(src => src.ControlStation.Name));
        }
    }
}
