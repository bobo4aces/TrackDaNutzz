namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class Client
    {
        public Client()
        {
            this.Tables = new List<Table>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}