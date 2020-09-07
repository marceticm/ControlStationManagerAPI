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
    public class ControlStationsController : ControllerBase // to do: implement logging
    {
        private readonly IControlStationService _controlStationService;
        private readonly int userId;

        public ControlStationsController(IControlStationService controlStationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _controlStationService = controlStationService;
            userId = 1;
            //userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public async Task<ActionResult> GetControlStations()
        {
            var result = await _controlStationService.GetControlStations(userId);
            return Ok(result);
        }

        [HttpGet("{stationId}")]
        public async Task<ActionResult<ControlStationDto>> GetControlStation(int stationId)
        {
            var result = await _controlStationService.GetControlStation(userId, stationId);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ControlStationDto>> CreateControlStation(ControlStationForCreateDto controlStation)
        {
            controlStation.UserId = userId;

            ControlStationDto createdStation;
            try
            {
                createdStation = await _controlStationService.Add(controlStation);
            }
            catch (InvalidControlStationException ex)
            {
                return BadRequest(ex.Message);
            }
            if (createdStation == null)
                return BadRequest();

            return Created("", createdStation);
            //return CreatedAtAction(nameof(GetControlStation), new { id = createdStation.Id }, createdStation);
        }

        [HttpPut("{stationId}")]
        public async Task<ActionResult<ControlStationDto>> UpdateControlStation(int stationId, ControlStationForCreateDto controlStation)
        {
            controlStation.UserId = userId;

            ControlStationDto result;
            try
            {
                result = await _controlStationService.Update(userId, stationId, controlStation);
            }
            catch (ControlStationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidControlStationException ex)
            {
                return BadRequest(ex.Message);
            }
            return result;
        }

        [HttpDelete("{stationId}")]
        public async Task<ActionResult<ControlStationDto>> DeleteControlStation(int stationId)
        {
            ControlStationDto result;
            try
            {
                result = await _controlStationService.Remove(userId, stationId);
            }
            catch (ControlStationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return result;
        }

    }
}
