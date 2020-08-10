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

        public async Task<bool> ControlStationExists(string name)
        {
            if (await _context.ControlStations.AnyAsync(x => x.Name == name))
                return true;

            return false;

        }

        public async Task<ControlStation> UpdateControlStation(int userId, ControlStation controlStation)
        {
            var result = await _context.ControlStations
                .FirstOrDefaultAsync(x => x.Id == controlStation.Id && x.UserId == userId);

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
