using ControlStationManager.DAL.Entities;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IControlStationRepository : IRepository<ControlStation>
    {
        Task<bool> ControlStationExists(int userId, int stationId, string stationName);
        Task<ControlStation> UpdateControlStation(int userId, int stationId, ControlStation controlStation);
    }
}
