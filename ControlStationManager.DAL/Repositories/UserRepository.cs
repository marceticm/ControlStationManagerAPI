using System.Threading.Tasks;
using ControlStationManager.DAL.Contexts;
using ControlStationManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlStationManager.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ControlStationContext _context;

        public UserRepository(ControlStationContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;


        }

        public async Task<User> UpdateUser(int userId, User user)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (result != null)
            {
                result.Username = user.Username;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.JobTitle = user.JobTitle;
                result.DateOfBirth = user.DateOfBirth;
                result.EmailAddress = user.EmailAddress;
                result.PhotoUrl = user.PhotoUrl;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<bool> UserExists(int userId, string userName)
        {
            bool result;
            if (userId == 0) // insert
            {
                result = await _context.Users.AnyAsync(x => x.Username == userName);
            }
            else // update
            {
                result = await _context.Users
                    .AnyAsync(x => x.Id != userId && x.Username == userName);
            }

            return result;
        }
    }
}
