namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Table
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public int ClientId { get; protected set; }

        public Client Client { get; protected set; }

        public int Size { get; protected set; }

        public string Currency { get; protected set; }

        public int VariantId { get; protected set; }

        public Variant Variant { get; protected set; }

        public int StakeId { get; protected set; }

        public Stake Stake { get; protected set; }

        public ICollection<Hand> Hands { get; protected set; }
    }
}