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

        public async Task<StationItem> Remove(int userId, int itemId)
        {
            var item = _context.StationItems
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == itemId);

            if (item != null)
            {
                _context.StationItems.Remove(item.Result);
                await _context.SaveChangesAsync();
                return item.Result;
            }
            return null;
        }

        public async Task<bool> SerialNumberExists(int stationId, int itemId, string serialNumber)
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

        public async Task<StationItem> Update(int userId, int stationId, int itemId, StationItem stationItem)
        {
            var result = await _context.StationItems
                .FirstOrDefaultAsync(x => x.Id == itemId && x.UserId == userId && x.ControlStationId == stationId);

            if (result != null)
            {
                result.Type = stationItem.Type;
                result.SerialNumber = stationItem.SerialNumber;
                result.LastCheckDate = stationItem.LastCheckDate;
                result.NextCheckDate = stationItem.NextCheckDate;

                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
