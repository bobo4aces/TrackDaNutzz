namespace TrackDaNutzz.Data.Models
{
    public class HandPlayer
    {
        public long HandId { get; protected set; }
        public Hand Hand { get; protected set; }
        public int PlayerId { get; protected set; }
        public Player Player { get; protected set; }
    }
}
