using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;

namespace ControlStationManagerAPI.MapProfiles
{
    public class ControlStationMapProfile : Profile
    {
        public ControlStationMapProfile()
        {
            CreateMap<ControlStation, ControlStationDto>();
        }
    }
}
