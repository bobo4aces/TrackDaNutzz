namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Position
    {
        public Position()
        {
            this.HandPlayers = new List<HandPlayer>();
        }
        public int Id { get; set; }
        //UTG +3, UTG +2, UTG +1, MP +3, MP +2, MP +1, CO, BU, SB, BB
        public string Name { get; set; }
        //Early, Middle, Late
        public string Type { get; set; }

        public ICollection<HandPlayer> HandPlayers { get; set; }
    }
}