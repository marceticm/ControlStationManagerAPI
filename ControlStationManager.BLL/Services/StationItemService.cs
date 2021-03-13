using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;
using ControlStationManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public class StationItemService : IStationItemService
    {
        private readonly IStationItemRepository _itemRepository;
        private readonly IControlStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public StationItemService(IStationItemRepository itemRepository,
            IControlStationRepository stationRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _stationRepository = stationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ControlStationItemDto>> GetStationItems(int userId, int stationId)
        {
            var controlStation = await _stationRepository.Get(userId, stationId);
            if (controlStation == null)
            {
                throw new ControlStationNotFoundException(stationId);
            }

            var stationItems = await _itemRepository.GetAll(userId, stationId);
            return _mapper.Map<IEnumerable<ControlStationItemDto>>(stationItems);
        }

        public async Task<ControlStationItemDto> GetStationItem(int userId, int stationId, int itemId)
        {
            var stationitem = await _itemRepository.Get(userId, stationId, itemId);
            return _mapper.Map<ControlStationItemDto>(stationitem);
        }

        public async Task<ControlStationItemDto> Add(int userId, int stationId, StationItemForCreateDto stationItem)
        {
            if (stationItem == null)
                return null;

            var controlStation = await _stationRepository.Get(userId, stationId);
            if (controlStation == null)
            {
                throw new ControlStationNotFoundException(stationId);
            }

            await CheckSerialNumber(stationId, 0, stationItem.SerialNumber);

            var mappedStationItem = _mapper.Map<StationItem>(stationItem);
            mappedStationItem.ControlStationId = stationId;
            mappedStationItem.UserId = userId;
            var createdStation = await _itemRepository.Add(mappedStationItem);

            return _mapper.Map<ControlStationItemDto>(createdStation);
        }

        public async Task<ControlStationItemDto> Update(int userId, int stationId, int itemId, StationItemForCreateDto stationItem)
        {
            await CheckIfItemExists(userId, stationId, itemId);
            await CheckSerialNumber(stationId, itemId, stationItem.SerialNumber);

            var mappedStationItem = _mapper.Map<StationItem>(stationItem);
            var updatedItem = await _itemRepository.Update(userId, stationId, itemId, mappedStationItem);
            if (updatedItem == null)
            {
                throw new StationItemNotFoundException(stationId);
            }

            return _mapper.Map<ControlStationItemDto>(updatedItem);
        }

        public async Task<ControlStationItemDto> Remove(int userId, int controlStationId, int itemId)
        {
            await CheckIfItemExists(userId, controlStationId, itemId);

            var deletedItem = await _itemRepository.Remove(userId, itemId);
            return _mapper.Map<ControlStationItemDto>(deletedItem);
        }

        #region Helpers
        private async Task CheckIfItemExists(int userId, int stationId, int itemId)
        {
            var itemToUpdate = await GetStationItem(userId, stationId, itemId);
            if (itemToUpdate == null)
            {
                throw new StationItemNotFoundException(itemId);
            }
        }

        private async Task CheckSerialNumber(int stationId, int itemId, string serialNumber)
        {
            if (await _itemRepository.SerialNumberExists(stationId, itemId, serialNumber))
            {
                throw new InvalidControlStationItemException(serialNumber);
            }
        }
        #endregion
    }

    [Serializable]
    public class StationItemNotFoundException : Exception
    {
        public StationItemNotFoundException()
        {
        }

        public StationItemNotFoundException(int itemId)
            : base(String.Format($"Station item with id = {itemId} not found."))
        {

        }
    }

    [Serializable]
    public class InvalidControlStationItemException : Exception
    {
        public InvalidControlStationItemException()
        {

        }

        public InvalidControlStationItemException(string serialNumber)
        : base(String.Format("ControlStation Item with serial number: {0} already exists.", serialNumber))
        {

        }
    }
}
