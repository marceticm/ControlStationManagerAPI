using ControlStationManager.DAL.Models;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public interface IUserService
    {
        Task<UserForDisplayDto> GetUser(int userId);
        Task<UserForDisplayDto> UpdateUser(int userId, UserForUpdateDto user);
    }
}
