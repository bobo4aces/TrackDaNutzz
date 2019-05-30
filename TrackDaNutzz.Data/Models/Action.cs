namespace TrackDaNutzz.Data.Models
{
    public class Action
    {
        public int Id { get; protected set; }

        public string Street { get; protected set; }

        public int PlayerId { get; protected set; }

        public Player Player { get; protected set; }

        public string Name { get; protected set; }

        public decimal? Value { get; protected set; }

        public bool IsAllIn { get; protected set; }

        public long HandId { get; protected set; }

        public Hand Hand { get; protected set; }
    }
}