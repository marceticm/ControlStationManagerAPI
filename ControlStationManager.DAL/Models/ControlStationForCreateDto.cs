using System.ComponentModel.DataAnnotations;

namespace ControlStationManager.DAL.Models
{
    public class ControlStationForCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
    }
}
