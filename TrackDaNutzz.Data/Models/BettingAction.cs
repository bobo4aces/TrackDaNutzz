namespace TrackDaNutzz.Data.Models
{
    using System.Collections.Generic;

    public class BettingAction
    {
        public long Id { get; protected set; }
        //Preflop, Flop, Turn, River, Rounds in Draw Games, Stud Games etc
        public string Round { get; protected set; }
        //Passive (0) and Active (1)
        public bool Type { get; protected set; }
        //Fold, Check, Post Ante, Post SB, Post BB, Call, Bet, Raise
        public string Name { get; protected set; }

        public decimal? Value { get; protected set; }

        //public ICollection<HandPlayer> HandPlayers { get; protected set; }
    }
}