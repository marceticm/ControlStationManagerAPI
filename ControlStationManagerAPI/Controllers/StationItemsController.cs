using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlStationManagerAPI.Controllers
{
    [Authorize]
    [Route("api/ControlStations/{controlStationId}/[controller]")]
    [ApiController]
    public class StationItemsController : ControllerBase
    {
        //private readonly IStationItemService _stationItemService;
        private readonly int userId;

        public StationItemsController()
        {

        }

        //[HttpGet]
        //public async Task<ActionResult> GetStationItems()
        //{
        //    //var result = await _stationItemService.GetControlStations(userId);
        //    //return Ok(result);
        //}
    }
}