namespace TrackDaNutzz.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hand
    {
        public long Id { get; set; }

        public long Number { get; set; }

        public DateTime Time { get; set; }

        [Range(1, 10)]
        public int Button { get; set; }

        public decimal Pot { get; set; }

        public decimal Rake { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public long? BoardId { get; set; }

        public Board Board { get; set; }

        public ICollection<HandPlayer> HandPlayers { get; set; }
    }
}
	