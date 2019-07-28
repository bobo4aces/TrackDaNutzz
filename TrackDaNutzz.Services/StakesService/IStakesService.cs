using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.StakesService
{
    public interface IStakesService
    {
        int AddStake(HandInfoDto handInfoDto);
    }
}
