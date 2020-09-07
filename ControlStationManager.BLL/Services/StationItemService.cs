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
        private readonly IStationItemRepository _repository;
        private readonly IMapper _mapper;

        public Task<ControlStationItemDto> GetStationItem(int userId, int stationId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ControlStationItemDto>> GetStationItems(int userId, int stationId)
        {
            throw new NotImplementedException();
        }
    }
}
