using ControlStationManager.BLL.Services;
using ControlStationManager.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControlStationManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ControlStationController : ControllerBase
    {
        private readonly IControlStationService _controlStationService;

        public ControlStationController(IControlStationService controlStationService)
        {
            _controlStationService = controlStationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetControlStations()
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _controlStationService.GetControlStations(userId);
            return Ok(result);
        }

        [HttpGet("{stationId}")]
        public async Task<ActionResult<ControlStationDto>> GetControlStation(int stationId)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _controlStationService.GetControlStation(userId, stationId);
            if (result == null)
                return NotFound();

            return result;
        }



    }
}
