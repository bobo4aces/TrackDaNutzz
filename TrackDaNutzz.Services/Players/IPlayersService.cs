using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Dtos.Statistics;

namespace TrackDaNutzz.Services.Players
{
    public interface IPlayersService
    {
        Dictionary<string, int> AddPlayers(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId);
        IQueryable<StatisticsAllByPlayerNameDto> GetAllStatisticsByPlayerId(int activePlayerId, params int[] playerIds);

        IQueryable<int> GetAllPlayerIds(string userId, int activePlayerId);
        IEnumerable<StatisticsAllByImportStakeDto> GetPlayerStakeStatistics(int playerId);

        IQueryable<PlayerDto> GetPlayersByUserId(string userId);

        bool RemoveActivePlayer(int playerId, string userId);
        bool RemoveActivePlayer(string userId);
        bool ChangeActivePlayer(string userId, int oldPlayerId, int newPlayerId);
        bool SetActivePlayer(int playerId, string userId);
        PlayerDto GetActivePlayer(string userId);
    }
}
