using ControlStationManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public interface IStationItemService
    {
        Task<IEnumerable<ControlStationItemDto>> GetStationItems(int userId, int stationId);
        Task<ControlStationItemDto> GetStationItem(int userId, int stationId, int itemId);
        Task<ControlStationItemDto> Add(int userId, int controlStationId, StationItemForCreateDto stationItem);
        Task<ControlStationItemDto> Update(int userId, int stationId, int itemId, StationItemForCreateDto stationItem);
        //Task<ControlStationItemDto> Remove(int userId, int stationId);
    }
}
