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

        public async Task<ControlStationDto> Add(ControlStationForCreateDto controlStation)
        {
            if (controlStation == null)
                return null;

            if (await _repository.ControlStationExists(controlStation.UserId,
                0, controlStation.Name))
            {
                throw new InvalidControlStationException(controlStation.Name);
            }

            var mappedStation = _mapper.Map<ControlStation>(controlStation);
            var createdStation = await _repository.Add(mappedStation);

            return _mapper.Map<ControlStationDto>(createdStation);
        }

        public async Task<ControlStationDto> Update(int userId, int stationId,
            ControlStationForCreateDto controlStation)
        {
            if (await _repository.ControlStationExists(controlStation.UserId,
                stationId, controlStation.Name))
            {
                throw new InvalidControlStationException(controlStation.Name);
            }

            var stationToUpdate = await GetControlStation(userId, stationId);
            if (stationToUpdate == null)
            {
                throw new ControlStationNotFoundException(stationId);
            }

            var mappedStation = _mapper.Map<ControlStation>(controlStation);
            var updatedStation = await _repository.UpdateControlStation(userId, stationId, mappedStation);
            if (updatedStation == null)
            {
                throw new ControlStationNotFoundException(stationId);
            }

            return _mapper.Map<ControlStationDto>(updatedStation);
        }


        public async Task<ControlStationDto> Remove(int userId, int stationId)
        {
            var stationToDelete = await GetControlStation(userId, stationId);
            if (stationToDelete == null)
            {
                throw new ControlStationNotFoundException(stationId);
            }

            var deletedStation = await _repository.Remove(userId, stationId);
            return _mapper.Map<ControlStationDto>(deletedStation);
        }


    }

    [Serializable]
    public class InvalidControlStationException : Exception
    {
        public InvalidControlStationException()
        {

        }

        public InvalidControlStationException(string name)
        : base(String.Format("ControlStation with name: {0} already exists.", name))
        {

        }
    }

    [Serializable]
    public class ControlStationNotFoundException : Exception
    {
        public ControlStationNotFoundException()
        {

        }

        public ControlStationNotFoundException(int stationId)
        : base(String.Format($"Control Station with id = {stationId} not found."))
        {

        }
    }


}
