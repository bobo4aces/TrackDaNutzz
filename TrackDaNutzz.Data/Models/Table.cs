namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Table
    {
        public int Id { get; protected set; }

        public string Client { get; protected set; }

        public string Name { get; protected set; }

        public string Size { get; protected set; }

        public string Currency { get; protected set; }

        public string Format { get; protected set; }

        public string Limit { get; protected set; }

        public decimal SmallBlind { get; protected set; }

        public decimal BigBlind { get; protected set; }

        public ICollection<Hand> Hands { get; protected set; }
    }
}