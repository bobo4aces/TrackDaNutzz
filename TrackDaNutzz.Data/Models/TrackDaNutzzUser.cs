namespace TrackDaNutzz.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class TrackDaNutzzUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Password { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}