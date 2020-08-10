﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;

namespace ControlStationManager.BLL.Services
{
    public interface IControlStationService
    {
        Task<IEnumerable<ControlStationDto>> GetControlStations(int userId);
        Task<ControlStationDto> GetControlStation(int userId, int stationId);
        Task<ControlStationDto> Add(ControlStationForCreateDto controlStation);
        Task<ControlStationDto> Update(int userId, int stationId, ControlStationForCreateDto controlStation);
        void Remove(ControlStation entity);
    }
}