using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Seats
{
    public class SeatInfoDto
    {
        public int SeatNumber { get; set; }
        public string PlayerName { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal Money { get; set; }
    }
}
