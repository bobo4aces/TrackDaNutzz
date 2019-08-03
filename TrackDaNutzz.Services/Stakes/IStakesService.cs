using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Stakes;
using TrackDaNutzz.Services.Dtos.Statistics;

namespace TrackDaNutzz.Services.Stakes
{
    public interface IStakesService
    {
        int AddStake(HandInfoDto handInfoDto);
        IQueryable<StakeDto> GetStakeByStakeId(params int[] stakeIds);
        //List<StatisticsAllByImportStakeDto> GetStakesByPlayerId(int playerId);
    }
}
