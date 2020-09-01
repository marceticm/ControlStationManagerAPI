using System;
using System.Collections.Generic;
using System.Text;

namespace ControlStationManager.DAL.Models
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoUrl { get; set; }
    }
}
