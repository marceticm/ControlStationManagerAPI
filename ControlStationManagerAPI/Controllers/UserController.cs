using ControlStationManager.BLL.Services;
using ControlStationManager.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControlStationManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly int userId;

        public UserController(IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            //userId = 4;
            userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public async Task<ActionResult<UserForDisplayDto>> GetControlStation()
        {
            var result = await _userService.GetUser(userId);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPut] // NOT tested yet
        public async Task<ActionResult<UserForDisplayDto>> UpdateControlStation(UserForUpdateDto user)
        {
            UserForDisplayDto result;
            try
            {
                result = await _userService.UpdateUser(userId, user);
            }
            catch (InvalidUsernameException ex)
            {
                return BadRequest(ex.Message);
            }
            return result;
        }
    }
}