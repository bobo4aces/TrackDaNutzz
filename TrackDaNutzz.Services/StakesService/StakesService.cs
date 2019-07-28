using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.StakesService
{
    public class StakesService : IStakesService
    {
        private readonly TrackDaNutzzDbContext context;

        public StakesService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

        public int AddStake(HandInfoDto handInfoDto)
        {
            Stake stake = this.context.Stakes
                .SingleOrDefault(s => s.BigBlind == handInfoDto.BigBlind && s.SmallBlind == handInfoDto.SmallBlind &&
                                    s.Currency == handInfoDto.Currency && s.CurrencySymbol == handInfoDto.CurrencySymbol);
            if (stake != null)
            {
                return stake.Id;
            }
            stake = new Stake()
            {
                Currency = handInfoDto.Currency,
                CurrencySymbol = handInfoDto.CurrencySymbol,
                BigBlind = handInfoDto.BigBlind,
                SmallBlind = handInfoDto.SmallBlind
            };
            this.context.Stakes.Add(stake);
            this.context.SaveChanges();
            return stake.Id;
        }
    }
}
