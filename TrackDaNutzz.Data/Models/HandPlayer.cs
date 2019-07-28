namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class HandPlayer
    {
        private string bettingActionIdsJoinByPipe;
        private List<long> bettingActionIds;
        public HandPlayer()
        {
            this.BettingActionIds = new List<long>();
        }
        public long HandId { get; set; }

        public Hand Hand { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public decimal StartingStack { get; set; }

        public decimal FinalStack { get; set; }

        public decimal StackDifference { get; set; }

        public int SeatNumber { get; set; }

        public string HoleCards { get; set; }

        public bool IsInPosition { get; set; }

        public bool IsMuckCards { get; set; }

        public bool HasShowdown { get; set; }

        public bool IsAllIn { get; set; }

        public string BettingActionIdsJoinByPipe
        {
            get
            {
                return string.Join("|", this.bettingActionIds);
            }
            set
            {
                this.bettingActionIdsJoinByPipe = value;
            }
        }
        [NotMapped]
        public List<long> BettingActionIds
        {
            get
            {
                return this.bettingActionIds;
            }
            set
            {
                this.bettingActionIds = value;
                this.bettingActionIdsJoinByPipe = string.Join("|", value);
            }
        }

        public long StatisticId { get; set; }

        public Statistic Statistic { get; set; }
    }
}
