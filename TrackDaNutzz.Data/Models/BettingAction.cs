namespace TrackDaNutzz.Data.Models
{
    public class BettingAction
    {
        public long Id { get; protected set; }
        public string Street { get; protected set; }
        //Passive (0) and Active (1)
        public bool Type { get; protected set; }
        //Fold, Check, Post SB, Post BB, Call, Bet, Raise
        public string Name { get; protected set; }
        public decimal? Value { get; protected set; }
    }
}