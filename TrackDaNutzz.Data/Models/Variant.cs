namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Variant
    {
        public Variant()
        {
            this.Tables = new List<Table>();
        }
        public int Id { get; set; }

        //HoldEm, Omaha, 7 Stud, 5 Draw, HORSE
        public string Name { get; set; }

        //No Limit, Pot Limit, Fixed Limit
        public string Limit { get; set; }

        public ICollection<Table> Tables { get; set; }

        //public bool HasAnte { get; set; }
        //Draw, Stud, Community Card, Mixed
        //public string Type { get; set; }
    }
}