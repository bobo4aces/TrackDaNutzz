using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Statistics
{
    public class StatisticsDto
    {
        public long Id { get; set; }

        public bool VoluntaryPutMoneyInPot { get; set; }

        public bool PreFlopRaise { get; set; }

        public bool ThreeBet { get; set; }

        public bool FourBet { get; set; }

        public int TotalCalls { get; set; }
        public int TotalBets { get; set; }
        public int TotalRaises { get; set; }

        public bool ContinuationBet { get; set; }

        public decimal BigBlindsWon { get; set; }

        public decimal MoneyWon { get; set; }
    }
}
