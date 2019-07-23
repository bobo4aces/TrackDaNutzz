using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Summary
{
    public class MuckSummaryDto
    {
        public int SeatNumber { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public string FirstCard { get; set; }
        public string SecondCard { get; set; }
    }
}
