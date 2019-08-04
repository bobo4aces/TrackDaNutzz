namespace TrackDaNutzz.Services.Dtos.Stakes
{
    public class StakeDto
    {
        public int Id { get; set; }

        public string Currency { get; set; }

        public char CurrencySymbol { get; set; }

        public decimal SmallBlind { get; set; }

        public decimal BigBlind { get; set; }
    }
}
