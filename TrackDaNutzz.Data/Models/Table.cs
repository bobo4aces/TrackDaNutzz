namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Table
    {
        public Table()
        {
            this.Hands = new List<Hand>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClientId { get; set; }
        
        public Client Client { get; set; }

        public int Size { get; set; }

        //public string Currency { get; set; }
        //
        public int VariantId { get; set; }
        
        public Variant Variant { get; set; }
        
        public int StakeId { get; set; }
        
        public Stake Stake { get; set; }

        public ICollection<Hand> Hands { get; set; }
    }
}