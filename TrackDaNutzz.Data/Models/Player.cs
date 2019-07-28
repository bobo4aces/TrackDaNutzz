namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public Player()
        {
            this.HandPlayers = new List<HandPlayer>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        //public bool IsActive { get; set; }
        public string TrackDaNutzzUserId { get; set; }
        public TrackDaNutzzUser TrackDaNutzzUser { get; set; }


        public ICollection<HandPlayer> HandPlayers { get; set; }
    }
}