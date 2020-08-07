using System;

namespace ControlStationManager.DAL.Models
{
    public class ControlStationItemDto
    {
        public int Id { get; set; }
        public DateTime LastCheckDate { get; set; }
        public DateTime NextCheckDate { get; set; }
        public ControlStationDto ControlStation { get; set; }
        public int ControlStationId { get; set; }
    }
}
