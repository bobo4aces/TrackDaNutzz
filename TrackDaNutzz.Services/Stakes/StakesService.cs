using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Stakes;
using TrackDaNutzz.Services.Dtos.Statistics;

namespace TrackDaNutzz.Services.Stakes
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

        public IQueryable<StakeDto> GetStakeByStakeId(params int[] stakeIds)
        {
            IQueryable<StakeDto> stakes = this.context.Stakes
                .Where(s => stakeIds.Contains(s.Id))
                .Select(x=>new StakeDto
                {
                    Id = x.Id,
                    BigBlind = x.BigBlind,
                    Currency = x.Currency,
                    CurrencySymbol = x.CurrencySymbol,
                    SmallBlind = x.SmallBlind,
                });
            return stakes;
        }


        //public List<StatisticsAllByImportStakeDto> GetStakesByPlayerId(int playerId)
        //{
        //    var statisticsAllByImportStakeDtos = this.context.Stakes
        //        .SelectMany(x => x.Tables
        //            .SelectMany(y => y.Hands
        //                .Select(z => z.HandPlayers
        //                    .Where(xx => xx.PlayerId == playerId)
        //                    .Select(xx => new StatisticsAllByImportStakeDto()
        //                    {
        //                        BigBlind = x.BigBlind,
        //                        SmallBlind = x.SmallBlind,
        //                        BigBlindsWon = z.HandPlayers.Sum(yy => yy.Statistic.BigBlindsWon),
        //                    }).ToList())));
        //    List<StatisticsAllByImportStakeDto> nwq = new List<StatisticsAllByImportStakeDto>();
        //    return nwq;
        //}
    }
}
