using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.Players
{
    public interface IPlayersService
    {
        Dictionary<string, int> AddPlayers(HandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId);
    }
}
