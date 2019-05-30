namespace TrackDaNutzz.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Hand
    {
        public long Id { get; protected set; }

        public long Number { get; protected set; }

        public DateTime Time { get; protected set; }

        [Range(1, 10)]
        public int Button { get; protected set; }

        public decimal TotalPot { get; protected set; }

        public decimal Rake { get; protected set; }

        public int TableId { get; protected set; }

        public Table Table { get; protected set; }
    }
}
	