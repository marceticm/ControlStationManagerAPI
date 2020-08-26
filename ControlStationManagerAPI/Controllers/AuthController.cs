using ControlStationManager.BLL.Services;
using ControlStationManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlStationManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserForDisplayDto result;
            try
            {
                result = await _authService.Register(user);
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("GetUserTest", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto user)
        {
            var token = await _authService.Login(user);
            if (token == null)
                return Unauthorized();

            return Ok(new {token});
        }
    }
}
