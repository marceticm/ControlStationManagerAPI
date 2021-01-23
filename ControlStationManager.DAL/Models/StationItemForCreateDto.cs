using System;

namespace ControlStationManager.DAL.Models
{
    public class StationItemForCreateDto
    {
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public DateTime LastCheckDate { get; set; }
        public DateTime NextCheckDate { get; set; }
    }
}
