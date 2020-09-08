using AutoMapper;
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
            throw new NotImplementedException();
        }


    }
}
