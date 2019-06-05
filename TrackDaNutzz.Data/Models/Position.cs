namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Position
    {
        public int Id { get; protected set; }
        //UTG +3, UTG +2, UTG +1, MP +3, MP +2, MP +1, CO, BU, SB, BB
        public string Name { get; protected set; }
        //Early, Middle, Late
        public string Type { get; protected set; }

        public ICollection<HandPlayer> HandPlayers { get; protected set; }
    }
}