using System;

namespace ControlStationManager.DAL.Models
{
    public class ControlStationItemDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public DateTime LastCheckDate { get; set; }
        public DateTime NextCheckDate { get; set; }
        public string ControlStationName { get; set; }
    }
}
