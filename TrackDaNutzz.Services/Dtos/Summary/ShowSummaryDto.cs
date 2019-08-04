namespace TrackDaNutzz.Services.Dtos.Summary
{
    public class ShowSummaryDto
    {
        public int SeatNumber { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public string FirstCard { get; set; }
        public string SecondCard { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal Value { get; set; }
        public string HandStrength { get; set; }
    }
}
