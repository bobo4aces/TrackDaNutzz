using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.BettingActions
{
    public class BettingActionDto
    {
        public string PlayerName { get; set; }
        public string Action { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal? Value { get; set; }
        public decimal? RaiseTo { get; set; }
        public bool? IsAllIn { get; set; }
    }
}
