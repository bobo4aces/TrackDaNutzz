namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Board
    {
        public Board()
        {
            this.Hands = new List<Hand>();
        }
        public long Id { get; set; }

        public string Flop { get; set; }

        public string Turn { get; set; }

        public string River { get; set; }

        public ICollection<Hand> Hands { get; set; }
    }
}