namespace TrackDaNutzz.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public DateTime Birthday { get; protected set; }

        public string Password { get; protected set; }

        public ICollection<Player> Players { get; protected set; }
    }
}