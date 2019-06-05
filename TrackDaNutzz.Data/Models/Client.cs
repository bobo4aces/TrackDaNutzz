namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Client
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public ICollection<Table> Tables { get; protected set; }
    }
}