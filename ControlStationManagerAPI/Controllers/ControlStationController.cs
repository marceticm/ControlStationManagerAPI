﻿using ControlStationManager.BLL.Services;
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
    public class ControlStationController : ControllerBase
    {
        private readonly IControlStationService _controlStationService;
        private readonly int userId;

        public ControlStationController(IControlStationService controlStationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _controlStationService = controlStationService;
            userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
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

            try
            {
                var result = await _controlStationService.Update(userId, stationId, controlStation);
                return result;
            }
            catch (ControlStationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidControlStationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
