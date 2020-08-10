using ControlStationManager.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IControlStationRepository : IRepository<ControlStation>
    {
        Task<bool> ControlStationExists(string name);
        Task<ControlStation> UpdateControlStation(int userId, ControlStation controlStation);
    }
}
