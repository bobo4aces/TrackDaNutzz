using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.BettingActions
{
    public interface IBettingActionsService
    {
        List<long> AddBettingActions(HandDto handDto, long handId, Dictionary<string, int> playerIdsByName);
    }
}
