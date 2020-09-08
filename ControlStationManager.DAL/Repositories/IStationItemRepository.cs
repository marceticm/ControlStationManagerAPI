using ControlStationManager.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IStationItemRepository
    {
        Task<IEnumerable<StationItem>> GetAll(int userId, int stationId);
        Task<StationItem> Get(int userId, int stationId, int itemId);
        Task<StationItem> Add(StationItem entity);
        Task<StationItem> Remove(int userId, int id);
    }
}
