using System.Collections.Generic;

namespace TrackDaNutzz.Data.Models
{
    public class Statistic
    {
        public long Id { get; protected set; }

        public bool VoluntaryPutMoneyInPot { get; protected set; }

        public bool PreFlopRaise { get; protected set; }

        public bool ThreeBet { get; protected set; }

        public bool FourBet { get; protected set; }

        public bool AggressionFactor { get; protected set; }

        public bool ContinuationBet { get; protected set; }

        public double BigBlindsWon { get; protected set; }

        public decimal MoneyWon { get; protected set; }

        public ICollection<HandPlayer> HandPlayers { get; protected set; }
    }
}
