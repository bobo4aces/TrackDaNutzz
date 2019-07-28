namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Stake
    {
        public Stake()
        {
            this.Tables = new List<Table>();
        }
        public int Id { get; set; }

        public string Currency { get; set; }
        public char CurrencySymbol { get; set; }
        public decimal SmallBlind { get; set; }

        public decimal BigBlind { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}