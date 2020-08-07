using System;
using System.Collections.Generic;
using System.Text;

namespace ControlStationManager.DAL.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
