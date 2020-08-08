using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;
using ControlStationManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public class ControlStationService : IControlStationService
    {
        private readonly IControlStationRepository _repository;
        private readonly IMapper _mapper;

        public ControlStationService(IControlStationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ControlStationDto>> GetControlStations(int userId)
        {
            var controlStations = await _repository.GetAll(userId);
            return _mapper.Map<IEnumerable<ControlStationDto>>(controlStations);
        }

        public async Task<ControlStationDto> GetControlStation(int userId, int stationId)
        {
            var controlStation = await _repository.Get(userId, stationId);
            return _mapper.Map<ControlStationDto>(controlStation);
        }

        public void Add(ControlStation entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ControlStation entity)
        {
            throw new NotImplementedException();
        }


    }
}
