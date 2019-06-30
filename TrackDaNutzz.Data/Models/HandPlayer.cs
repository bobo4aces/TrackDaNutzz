namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class HandPlayer
    {
        public long HandId { get; set; }
        public Hand Hand { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }


        public decimal StartingStack { get; set; }

        public decimal FinalStack { get; set; }

        public int SeatNumber { get; set; }

        public string HoleCards { get; set; }

        public bool IsInPosition { get; set; }

        public bool IsMuckCards { get; set; }

        public bool HasShowdown { get; set; }

        public bool IsAllIn { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public long StatisticId { get; set; }

        public Statistic Statistic { get; set; }

        public ICollection<BettingAction> BettingActions { get; set; }

        //TODO: Add Many To Many Relation with Betting Actions
    }
}
