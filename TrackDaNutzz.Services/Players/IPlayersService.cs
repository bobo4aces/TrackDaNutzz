using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Dtos.Statistics;

namespace TrackDaNutzz.Services.Players
{
    public interface IPlayersService
    {
        Dictionary<string, int> AddPlayers(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId);
        IQueryable<PlayerTotalEarningsDto> GetTotalEarningsForAllPlayers();
        IQueryable<StatisticsAllByPlayerNameDto> GetAllStatisticsByPlayerId(params int[] playerIds);

        IQueryable<int> GetAllPlayerIds(string userId);
        IEnumerable<StatisticsAllByImportStakeDto> GetPlayerStakeStatistics(int playerId);
    }
}
