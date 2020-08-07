using ControlStationManager.DAL.Models;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public interface IAuthService
    {
        Task<UserForDisplayDto> Register(UserForRegisterDto userForRegisterDto);
        Task<string> Login(UserForLoginDto userForRegisterDto);
    }
}
