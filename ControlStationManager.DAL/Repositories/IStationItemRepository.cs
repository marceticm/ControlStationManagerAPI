using ControlStationManager.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IStationItemRepository
    {
        Task<IEnumerable<StationItem>> GetAll(int userId);
        Task<StationItem> Get(int userId, int id);
        Task<StationItem> Add(StationItem entity);
        Task<StationItem> Remove(int userId, int id);
    }
}
