namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Variant
    {
        public int Id { get; protected set; }

        //HoldEm, Omaha, 7 Stud, 5 Draw, HORSE
        public string Name { get; protected set; }

        //Draw, Stud, Community Card, Mixed
        public string Type { get; protected set; }
        
        //No Limit, Pot Limit, Fixed Limit
        public string Limit { get; protected set; }

        public bool HasAnte { get; protected set; }

        public ICollection<Table> Tables { get; protected set; }
    }
}