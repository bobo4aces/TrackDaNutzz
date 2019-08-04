using TrackDaNutzz.Services.Helpers;

namespace TrackDaNutzz.Services.Dtos.Statistics
{
    public class StatisticsAllByPlayerNameDto
    {

        public string PlayerName { get; set; }
        public int HandsPlayed { get; set; }
        public int TotalRaises { get; set; }
        public int TotalBets { get; set; }
        public int TotalCalls { get; set; }
        public double VoluntaryPutMoneyInPot { get; set; }

        public double PreFlopRaise { get; set; }

        public double ThreeBet { get; set; }

        public double FourBet { get; set; }
        public decimal AggressionFactor => MathOperations.Divide(this.TotalRaises + this.TotalBets, this.TotalCalls);

        public double ContinuationBet { get; set; }

        public decimal BigBlindsWon { get; set; }

        public decimal MoneyWon { get; set; }
    }
}
