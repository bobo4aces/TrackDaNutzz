namespace TrackDaNutzz.ViewModels
{
    public class StatisticsAllByPlayerNameViewModel
    {
        public string PlayerName { get; set; }
        public int HandsPlayed { get; set; }

        public double VoluntaryPutMoneyInPot { get; set; }

        public double PreFlopRaise { get; set; }

        public double ThreeBet { get; set; }

        public double FourBet { get; set; }

        public decimal AggressionFactor { get; set; }

        public double ContinuationBet { get; set; }

        public decimal BigBlindsWon { get; set; }

        public decimal MoneyWon { get; set; }
    }
}
