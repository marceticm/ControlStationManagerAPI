using System.Threading.Tasks;
using ControlStationManager.DAL.Contexts;
using ControlStationManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlStationManager.DAL.Repositories
{
    public class ControlStationRepository : Repository<ControlStation>, IControlStationRepository
    {
        private readonly ControlStationContext _context;

        public ControlStationRepository(ControlStationContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<bool> ControlStationExists(int userId, int stationId, string stationName)
        {
            bool result;
            if (stationId == 0) // insert
            {
                result = await _context.ControlStations
                    .AnyAsync(x => x.UserId == userId && x.Name == stationName);
            }
            else // update
            {
                result = await _context.ControlStations
                    .AnyAsync(x => x.UserId == userId && x.Id != stationId && x.Name == stationName);
            }

            return result;
        }

        public async Task<ControlStation> UpdateControlStation(int userId, 
            int stationId, ControlStation controlStation)
        {
            var result = await _context.ControlStations
                .FirstOrDefaultAsync(x => x.Id == stationId && x.UserId == userId);

            if (result != null)
            {
                result.Name = controlStation.Name;
                result.Type = controlStation.Type;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }


    }
}
