using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;
using ControlStationManager.DAL.Repositories;
using System;
using System.Collections.Generic;
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

            if (await _itemRepository.StationItemExists(stationId, 0, stationItem.SerialNumber))
            {
                throw new InvalidControlStationItemException(stationItem.SerialNumber);
            }

            var mappedStationItem = _mapper.Map<StationItem>(stationItem);
            mappedStationItem.ControlStationId = stationId;
            mappedStationItem.UserId = userId;
            var createdStation = await _itemRepository.Add(mappedStationItem);

            return _mapper.Map<ControlStationItemDto>(createdStation);
        }
    }
}
