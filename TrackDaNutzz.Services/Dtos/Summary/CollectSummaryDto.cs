using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Summary
{
    public class CollectSummaryDto
    {
        public int SeatNumber { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal Value { get; set; }
    }
}
