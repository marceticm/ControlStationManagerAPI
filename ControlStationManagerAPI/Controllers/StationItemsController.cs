using ControlStationManager.BLL.Services;
using ControlStationManager.DAL.Models;
using ControlStationManager.DAL.Repositories;
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

        [HttpGet] // implement /all param
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

        [HttpGet("{stationItemId}")]
        public async Task<ActionResult<ControlStationItemDto>> GetStationItem(
            int controlStationId, int stationItemId)
        {
            var result = await _stationItemService.GetStationItem(userId, controlStationId, stationItemId);
            if (result == null)
                return NotFound();

            return result;
        }


        [HttpPost]
        public async Task<ActionResult<ControlStationItemDto>> CreateStationItem(
            int controlStationId, StationItemForCreateDto stationItem)
        {
            ControlStationItemDto createdItem;
            try
            {
                createdItem = await _stationItemService.Add(userId, controlStationId, stationItem);
            }
            catch (InvalidControlStationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            if (createdItem == null)
                return BadRequest();

            return Created("", createdItem);
            //return CreatedAtAction(nameof(GetControlStation), new { id = createdStation.Id }, createdStation);
        }

        [HttpPut("{itemId}")]
        public async Task<ActionResult<ControlStationItemDto>> UpdateStationItem(
            int controlStationId, int itemId, StationItemForCreateDto stationItem)
        {
            ControlStationItemDto updatedItem;
            try
            {
                updatedItem = await _stationItemService.Update(userId, controlStationId, itemId, stationItem);
            }
            catch (StationItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidControlStationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            return updatedItem;
        }
    }
}