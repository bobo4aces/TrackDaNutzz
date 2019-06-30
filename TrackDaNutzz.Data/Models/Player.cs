namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<HandPlayer> HandPlayers { get; set; }
    }
}