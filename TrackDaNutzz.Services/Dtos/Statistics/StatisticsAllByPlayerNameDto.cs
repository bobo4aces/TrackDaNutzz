using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Statistics;

namespace TrackDaNutzz.Services.Dtos.Statistics
{
    public class StatisticsAllByPlayerNameDto
    {
        private decimal aggressionFactor;

        public string PlayerName { get; set; }
        public int HandsPlayed { get; set; }
        public int TotalRaises { get; set; }
        public int TotalBets { get; set; }
        public int TotalCalls { get; set; }
        public double VoluntaryPutMoneyInPot { get; set; }
        
        public double PreFlopRaise { get; set; }
        
        public double ThreeBet { get; set; }
        
        public double FourBet { get; set; }

        public decimal AggressionFactor
        {
            get
            {
                return this.aggressionFactor;
            }
            private set
            {
                int aggressiveBettingActionsCount = this.TotalRaises + this.TotalBets;
                int passiveBettingActionsCount = this.TotalCalls;
                decimal aggressionFactor = 0;
                if (aggressiveBettingActionsCount != 0 && passiveBettingActionsCount != 0)
                {
                    aggressionFactor = aggressiveBettingActionsCount / passiveBettingActionsCount;
                }
                else if (aggressiveBettingActionsCount != 0)
                {
                    aggressionFactor = aggressiveBettingActionsCount;
                }
                this.aggressionFactor = aggressionFactor;
            }
        }

        public double ContinuationBet { get; set; }

        public decimal BigBlindsWon { get; set; }
        
        public decimal MoneyWon { get; set; }
    }
}
