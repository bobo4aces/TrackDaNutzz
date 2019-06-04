namespace TrackDaNutzz.Data.Models
{
    public class Statistics
    {
        public long Id { get; protected set; }
        public bool VoluntaryPutInPot { get; protected set; }
        public bool PreFlopRaise { get; protected set; }
        public bool ThreeBet { get; protected set; }
        public bool FourBet { get; protected set; }
        public bool AggresionFactor { get; protected set; }
        public bool ContinuationBet { get; protected set; }
        public double BigBlindsWon { get; protected set; }
        public decimal DollarsWon { get; protected set; }
        public HandPlayer HandPlayer { get; protected set; }
        public long HandId { get; protected set; }
        public Hand Hand { get; protected set; }
        public int PlayerId { get; protected set; }
        public Player Player { get; protected set; }
    }
}
