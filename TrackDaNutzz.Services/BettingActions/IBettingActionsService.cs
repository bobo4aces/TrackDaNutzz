using System.Collections.Generic;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.BettingActions
{
    public interface IBettingActionsService
    {
        List<long> AddBettingActions(ImportHandDto handDto, long handId, Dictionary<string, int> playerIdsByName);
    }
}
