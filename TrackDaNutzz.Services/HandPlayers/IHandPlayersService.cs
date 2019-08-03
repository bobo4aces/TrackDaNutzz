using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;

namespace TrackDaNutzz.Services.HandPlayers
{
    public interface IHandPlayersService
    {
        bool AddHandPlayer(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, SeatInfoDto seatInfoDto, Player player);
        bool AddBettingAction(long bettingActionId, long handId, int playerId);

        IQueryable<long> GetAllHandIdsByPlayer(int playerId);
        IQueryable<long> GetStatisticIdsByPlayerIdAndHandId(int playerId, params long[] handIds);
    }
}
