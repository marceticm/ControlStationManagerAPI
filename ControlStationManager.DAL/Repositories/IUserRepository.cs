using ControlStationManager.DAL.Entities;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<User> UpdateUser(int userId, User user);
        Task<bool> UserExists(int userId, string userName);
    }
}
