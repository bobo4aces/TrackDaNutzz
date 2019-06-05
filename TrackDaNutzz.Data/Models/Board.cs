namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Board
    {
        public long Id { get; protected set; }

        public string Flop { get; protected set; }

        public string Turn { get; protected set; }

        public string River { get; protected set; }

        public ICollection<Hand> Hands { get; protected set; }
    }
}