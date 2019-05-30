namespace TrackDaNutzz.Data.Models
{
    public class Board
    {
        public int Id { get; protected set; }

        public string Flop { get; protected set; }

        public string Turn { get; protected set; }

        public string River { get; protected set; }

        public long HandId { get; protected set; }

        public Hand Hand { get; protected set; }
    }
}