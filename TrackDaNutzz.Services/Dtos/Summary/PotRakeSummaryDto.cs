using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Summary
{
    public class PotRakeSummaryDto
    {
        public string CurrencySymbol { get; set; }
        public decimal Pot { get; set; }
        public decimal Rake { get; set; }
    }
}
