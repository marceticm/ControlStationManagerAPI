using ControlStationManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public interface IStationItemService
    {
        Task<IEnumerable<ControlStationItemDto>> GetStationItems(int userId, int stationId);
        Task<ControlStationItemDto> GetStationItem(int userId, int stationId, int itemId);
        //Task<ControlStationItemDto> Add(ControlStationForCreateDto controlStation);
        //Task<ControlStationItemDto> Update(int userId, int stationId, ControlStationForCreateDto controlStation);
        //Task<ControlStationItemDto> Remove(int userId, int stationId);
    }
}
