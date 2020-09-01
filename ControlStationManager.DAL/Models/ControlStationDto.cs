using System.Collections.Generic;

namespace ControlStationManager.DAL.Models
{
    public class ControlStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public List<ControlStationItemDto> ControlStationItems { get; set; }
            = new List<ControlStationItemDto>();
    }
}
