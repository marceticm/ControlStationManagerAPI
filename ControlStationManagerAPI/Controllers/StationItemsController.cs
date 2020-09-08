using ControlStationManager.BLL.Services;
using ControlStationManager.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManagerAPI.Controllers
{
    [Authorize]
    [Route("api/ControlStations/{controlStationId}/[controller]")]
    [ApiController]
    public class StationItemsController : ControllerBase
    {
        private readonly IStationItemService _stationItemService;
        private readonly int userId;

        public StationItemsController(IStationItemService stationItemService,
            IHttpContextAccessor httpContextAccessor)
        {
            _stationItemService = stationItemService;
            userId = 1;
        }

        [HttpGet]
        public async Task<ActionResult<ControlStationItemDto>> GetStationItems(int controlStationId)
        {
            IEnumerable<ControlStationItemDto> result;
            try
            {
                result = await _stationItemService.GetStationItems(userId, controlStationId);
            }
            catch (ControlStationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(result);
        }
    }
}