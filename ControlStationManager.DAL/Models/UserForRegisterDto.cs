using System.ComponentModel.DataAnnotations;

namespace ControlStationManager.DAL.Models
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
