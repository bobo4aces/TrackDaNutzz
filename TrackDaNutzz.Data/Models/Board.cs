namespace TrackDaNutzz.Data.Models
{
    public class Board
    {
        public long Id { get; protected set; }

        public string Flop { get; protected set; }

        public string Turn { get; protected set; }

        public string River { get; protected set; }
    }
}