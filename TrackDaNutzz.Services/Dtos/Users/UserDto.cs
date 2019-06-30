using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Users
{
    public class UserDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
