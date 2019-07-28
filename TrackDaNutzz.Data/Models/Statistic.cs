using System.Collections.Generic;

namespace TrackDaNutzz.Data.Models
{
    public class Statistic
    {
        public Statistic()
        {
            this.HandPlayers = new List<HandPlayer>();
        }
        public long Id { get; set; }

        public bool VoluntaryPutMoneyInPot { get; set; }

        public bool PreFlopRaise { get; set; }

        public bool ThreeBet { get; set; }

        public bool FourBet { get; set; }

        public decimal AggressionFactor { get; set; }

        public bool ContinuationBet { get; set; }

        public double BigBlindsWon { get; set; }

        public decimal MoneyWon { get; set; }

        public ICollection<HandPlayer> HandPlayers { get; set; }
    }
}
