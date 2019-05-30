using System.ComponentModel.DataAnnotations;

namespace TrackDaNutzz.Data.Models
{
    public class Seat
    {
        public long Id { get; protected set; }

        [Range(10, 1)]
        public int Number { get; protected set; }

        public int PlayerId { get; protected set; }

        public Player Player { get; protected set; }

        public decimal StartStack { get; protected set; }

        public decimal FinalStack { get; protected set; }

        public string HoleCards { get; protected set; }

        public bool IsShowCards { get; protected set; }

        public long HandId { get; protected set; }

        public Hand Hand { get; protected set; }
    }
}