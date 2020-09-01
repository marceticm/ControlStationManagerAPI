using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStationManager.DAL.Entities
{
    public class ControlStation : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public string Address { get; set; }
        public List<StationItem> StationItems { get; set; } 
            = new List<StationItem>();
    }
}
