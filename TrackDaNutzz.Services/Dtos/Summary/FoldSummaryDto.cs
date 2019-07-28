using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Summary
{
    public class FoldSummaryDto
    {
        public int SeatNumber { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public bool IsBeforeRound { get; set; }
        public string Round { get; set; }
        public bool DidNotBet { get; set; }
    }
}
