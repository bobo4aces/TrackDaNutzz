namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class BettingAction
    {
        public long Id { get; set; }
        //Preflop, Flop, Turn, River, Rounds in Draw Games, Stud Games etc
        public string Round { get; set; }
        //Passive (0) and Active (1)
        public bool Type { get; set; }
        //Fold, Check, Post Ante, Post SB, Post BB, Call, Bet, Raise
        public string Name { get; set; }

        public decimal? Value { get; set; }

        //public ICollection<HandPlayer> HandPlayers { get; set; }
    }
}