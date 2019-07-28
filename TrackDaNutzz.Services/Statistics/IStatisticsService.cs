using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.Statistics
{
    public interface IStatisticsService
    {
        Dictionary<string, long> AddStatistics(HandDto handDto);
        Statistic CreateStatistic(HandDto handDto, string playerName, List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions, List<BettingActionDto> playerAllBettingActions);
        bool GetContinuationBet(List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions);
        double GetBigBlindsWon(decimal moneyWon, decimal bigBlind);
        decimal GetMoneyWon(List<BettingActionDto> playerAllBettingActions);
        decimal GetAggressionFactor(List<BettingActionDto> playerAllBettingActions);
        bool GetFourBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        bool GetThreeBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        bool GetPreFlopRaise(List<BettingActionDto> playerPreflopBettingActions);
        bool GetVoluntaryPutMoneyInPot(List<BettingActionDto> playerPreflopBettingActions);
    }
}
