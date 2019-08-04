using System.Linq;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Stakes;

namespace TrackDaNutzz.Services.Stakes
{
    public interface IStakesService
    {
        int AddStake(HandInfoDto handInfoDto);
        IQueryable<StakeDto> GetStakeByStakeId(params int[] stakeIds);
    }
}
