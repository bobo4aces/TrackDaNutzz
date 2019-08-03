using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.Statistics;

namespace TrackDaNutzz.Services.Statistics
{
    public interface IStatisticsService
    {
        Dictionary<string, long> AddStatistics(ImportHandDto handDto);
        Statistic CreateStatistic(ImportHandDto handDto, string playerName, List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions, List<BettingActionDto> playerAllBettingActions, SeatInfoDto seatInfoDto);
        bool GetContinuationBet(List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions);
        decimal GetBigBlindsWon(decimal moneyWon, decimal bigBlind);
        decimal GetMoneyWon(ImportHandDto handDto, SeatInfoDto seatInfoDto);
        decimal GetAggressionFactor(int totalRaises, int totalBets, int totalCalls);
        bool GetFourBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        bool GetThreeBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        bool GetPreFlopRaise(List<BettingActionDto> playerPreflopBettingActions);
        bool GetVoluntaryPutMoneyInPot(List<BettingActionDto> playerPreflopBettingActions);

        //IQueryable<StatisticsAllDto> GetAllStatisticsById(params long[] statisticsIds);
        IQueryable<StatisticsDto> GetStatisticsById(params long[] statisticsIds);
    }
}
