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
        private decimal stackDifference;
        public HandPlayer()
        {
            this.BettingActionIds = new List<long>();
            //this.BettingActions = new List<BettingAction>();
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

        //public bool IsInPosition { get; set; }

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

        //public int PositionId { get; set; }

        //public Position Position { get; set; }

        public long StatisticId { get; set; }

        public Statistic Statistic { get; set; }

        //public ICollection<BettingAction> BettingActions { get; set; }

        //TODO: Add Many To Many Relation with Betting Actions
    }
}
