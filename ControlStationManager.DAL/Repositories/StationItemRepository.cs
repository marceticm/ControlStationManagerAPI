using ControlStationManager.DAL.Contexts;
using ControlStationManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public class StationItemRepository : IStationItemRepository
    {
        private readonly ControlStationContext _context;

        public StationItemRepository(ControlStationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StationItem>> GetAll(int userId, int stationId)
        {
            return await _context.StationItems
                .Where(x => x.UserId == userId && x.ControlStationId == stationId)
                .ToListAsync();
        }

        public async Task<StationItem> Get(int userId, int stationId, int itemId)
        {
            return await _context.StationItems
                .Include(x => x.ControlStation)
                .FirstOrDefaultAsync(x => x.UserId == userId
                    && x.ControlStationId == stationId && x.Id == itemId);
        }

        public async Task<StationItem> Add(StationItem stationItem)
        {
            _context.Set<StationItem>().Add(stationItem);
            await _context.SaveChangesAsync();
            return stationItem;
        }

        public Task<StationItem> Remove(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StationItemExists(int stationId, int itemId, string serialNumber)
        {
            if (itemId == 0) // insert
            {
                return await _context.StationItems
                .AnyAsync(x => x.ControlStationId == stationId
                && x.SerialNumber == serialNumber);
            }
            else // update
            {
                return await _context.StationItems
                .AnyAsync(x => x.ControlStationId == stationId
                && x.Id != itemId
                && x.SerialNumber == serialNumber);
            }
        }
    }

    [Serializable]
    public class InvalidControlStationItemException : Exception
    {
        public InvalidControlStationItemException()
        {

        }

        public InvalidControlStationItemException(string serialNumber)
        : base(String.Format("ControlStation Item with serial number: {0} already exists.", serialNumber))
        {

        }
    }
}
