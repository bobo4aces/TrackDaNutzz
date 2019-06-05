namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class HandPlayer
    {
        public long HandId { get; protected set; }
        public Hand Hand { get; protected set; }
        public int PlayerId { get; protected set; }
        public Player Player { get; protected set; }


        public decimal StartingStack { get; protected set; }

        public decimal FinalStack { get; protected set; }

        public int SeatNumber { get; protected set; }

        public string HoleCards { get; protected set; }

        public bool IsInPosition { get; protected set; }

        public bool IsMuckCards { get; protected set; }

        public bool HasShowdown { get; protected set; }

        public bool IsAllIn { get; protected set; }

        public int PositionId { get; protected set; }

        public Position Position { get; protected set; }

        public long StatisticId { get; protected set; }

        public Statistic Statistic { get; protected set; }

        public ICollection<BettingAction> BettingActions { get; protected set; }

        //TODO: Add Many To Many Relation with Betting Actions
    }
}
