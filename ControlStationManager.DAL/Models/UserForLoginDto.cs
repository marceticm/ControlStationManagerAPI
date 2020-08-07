using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlStationManager.DAL.Models
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
