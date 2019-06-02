namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public decimal Stack { get; protected set; }
        public ICollection<HandPlayer> HandPlayers { get; protected set; }
    }
}