namespace TrackDaNutzz.Data.Models
{
    public class HandPlayer
    {
        public long HandId { get; protected set; }
        public Hand Hand { get; protected set; }
        public int PlayerId { get; protected set; }
        public Player Player { get; protected set; }
        public long StatisticsId { get; protected set; }
        public Statistics Statistics { get; protected set; }
        public int SeatNumber { get; protected set; }
        public decimal StartStack { get; protected set; }
        public decimal FinalStack { get; protected set; }
        public string HoleCards { get; protected set; }
        public bool IsShowCards { get; protected set; }
        public bool IsAllIn { get; protected set; }
    }
}
