using System;

namespace TrackDaNutzz.Services.Dtos.Hands
{
    public class HandInfoDto
    {
        public string ClientName { get; set; }
        public long HandNumber { get; set; }
        public string VariantName { get; set; }
        public string Limit { get; set; }
        public string Currency { get; set; }
        public char CurrencySymbol { get; set; }
        public decimal SmallBlind { get; set; }
        public decimal BigBlind { get; set; }
        public DateTime Time { get; set; }
        public string TimeZone { get; set; }
        public DateTime LocalTime { get; set; }
        public string LocalTimeZone { get; set; }
    }
}
