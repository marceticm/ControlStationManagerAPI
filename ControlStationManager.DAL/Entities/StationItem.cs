using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStationManager.DAL.Entities
{
    public class StationItem : BaseEntity
    {
        public DateTime LastCheckDate { get; set; }
        public DateTime NextCheckDate { get; set; }
        public ControlStation ControlStation { get; set; }
        public int ControlStationId { get; set; }
    }
}
