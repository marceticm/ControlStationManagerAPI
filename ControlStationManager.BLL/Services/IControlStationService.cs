using System.Collections.Generic;
using System.Threading.Tasks;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;

namespace ControlStationManager.BLL.Services
{
    public interface IControlStationService
    {
        void Add(ControlStation entity);
        Task<ControlStation> Get(int id);
        Task<IEnumerable<ControlStationDto>> GetControlStations(int userId);
        void Remove(ControlStation entity);
    }
}