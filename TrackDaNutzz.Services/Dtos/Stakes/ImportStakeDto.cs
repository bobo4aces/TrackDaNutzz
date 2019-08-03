using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Stakes
{
    public class ImportStakeDto
    {
        public int Id { get; set; }

        public string Currency { get; set; }

        public char CurrencySymbol { get; set; }

        public decimal SmallBlind { get; set; }

        public decimal BigBlind { get; set; }
    }
}
