using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.UncalledBets
{
    public class UncalledBetsDto
    {
        public string CurrencySymbol { get; set; }
        public decimal Value { get; set; }
        public string PlayerName { get; set; }
    }
}
