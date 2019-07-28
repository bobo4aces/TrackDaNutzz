using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Common;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly TrackDaNutzzDbContext context;

        public StatisticsService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

        public Dictionary<string, long> AddStatistics(HandDto handDto)
        {
            Dictionary<string, long> statisticsIdsByPlayerName = new Dictionary<string, long>();
            List<BettingActionDto> allBettingActions = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                    .SelectMany(b => b.BettingActionDtos)
                    .ToList();
            List<BettingActionDto> preflopBettingActions = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                    .Where(r => r.Round == RoundNamesConstants.Preflop)
                    .SelectMany(b => b.BettingActionDtos)
                    .ToList();
            List<BettingActionDto> flopBettingActions = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                    .Where(r => r.Round == RoundNamesConstants.Flop)
                    .SelectMany(b => b.BettingActionDtos)
                    .ToList();
            foreach (var seatInfoDtos in handDto.SeatInfoListDto.SeatInfoDtos)
            {
                string playerName = seatInfoDtos.PlayerName;
                List<BettingActionDto> playerPreflopBettingActions = preflopBettingActions
                    .Where(p => p.PlayerName == playerName)
                    .ToList();
                List<BettingActionDto> playerFlopBettingActions = flopBettingActions
                    .Where(p => p.PlayerName == playerName)
                    .ToList();
                List<BettingActionDto> playerAllBettingActions = allBettingActions
                    .Where(p => p.PlayerName == playerName)
                    .ToList();

                Statistic statistic = this.CreateStatistic(handDto, playerName, playerPreflopBettingActions, playerFlopBettingActions, playerAllBettingActions);
                Statistic statisticsFromDb = this.CheckDbForStatistics(statistic);
                if (statisticsFromDb == null)
                {
                    this.context.Statistics.Add(statistic);
                    this.context.SaveChanges();
                    statisticsIdsByPlayerName.Add(playerName, statistic.Id);
                }
                else
                {
                    statisticsIdsByPlayerName.Add(playerName, statisticsFromDb.Id);
                }
            }
            return statisticsIdsByPlayerName;
        }

        private Statistic CheckDbForStatistics(Statistic statistic)
        {
            return this.context.Statistics.SingleOrDefault(s =>
            s.AggressionFactor == statistic.AggressionFactor && s.BigBlindsWon == statistic.BigBlindsWon &&
            s.ContinuationBet == statistic.ContinuationBet && s.FourBet == statistic.FourBet &&
            s.MoneyWon == statistic.MoneyWon && s.PreFlopRaise == statistic.PreFlopRaise &&
            s.ThreeBet == statistic.ThreeBet && s.VoluntaryPutMoneyInPot == statistic.VoluntaryPutMoneyInPot);
        }

        public Statistic CreateStatistic(HandDto handDto, string playerName, List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions, List<BettingActionDto> playerAllBettingActions)
        {
            bool voluntaryPutMoneyInPot = this.GetVoluntaryPutMoneyInPot(playerPreflopBettingActions);
            bool preflopRaise = this.GetPreFlopRaise(playerPreflopBettingActions);
            bool threeBet = this.GetThreeBet(playerPreflopBettingActions, playerName);
            bool fourBet = this.GetFourBet(playerPreflopBettingActions, playerName);
            decimal aggressionFactor = this.GetAggressionFactor(playerAllBettingActions);
            decimal moneyWon = this.GetMoneyWon(playerAllBettingActions);
            double bigBlindsWon = this.GetBigBlindsWon(moneyWon, handDto.HandInfoDto.BigBlind);
            bool continuationBet = this.GetContinuationBet(playerPreflopBettingActions, playerFlopBettingActions);
            Statistic statistics = new Statistic()
            {
                VoluntaryPutMoneyInPot = voluntaryPutMoneyInPot,
                PreFlopRaise = preflopRaise,
                ThreeBet = threeBet,
                FourBet = fourBet,
                AggressionFactor = aggressionFactor,
                MoneyWon = moneyWon,
                BigBlindsWon = bigBlindsWon,
                ContinuationBet = continuationBet,
            };
            return statistics;
        }

        public bool GetContinuationBet(List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions)
        {
            if (playerPreflopBettingActions.Count == 0 || playerFlopBettingActions.Count == 0)
            {
                return false;
            }
            return (playerPreflopBettingActions.Last().Action == BettingActionNamesConstants.Bet ||
                    playerPreflopBettingActions.Last().Action == BettingActionNamesConstants.Raise) &&
                    (playerFlopBettingActions.First().Action == BettingActionNamesConstants.Bet ||
                    playerFlopBettingActions.First().Action == BettingActionNamesConstants.Raise);
        }

        public double GetBigBlindsWon(decimal moneyWon, decimal bigBlind)
        {
            if (moneyWon == 0)
            {
                return 0;
            }
            return (double)(moneyWon / bigBlind);
        }

        public decimal GetMoneyWon(List<BettingActionDto> playerAllBettingActions)
        {
            if (playerAllBettingActions.Count == 0)
            {
                return 0;
            }
            return playerAllBettingActions.Sum(a => a.Value ?? 0);
        }

        public decimal GetAggressionFactor(List<BettingActionDto> playerAllBettingActions)
        {
            if (playerAllBettingActions.Count == 0)
            {
                return 0;
            }
            int aggressiveBettingActionsCount = playerAllBettingActions
                                    .Where(a => a.Action == BettingActionNamesConstants.Bet || a.Action == BettingActionNamesConstants.Raise)
                                    .Count();
            int passiveBettingActionsCount = playerAllBettingActions
                                .Where(a => a.Action == BettingActionNamesConstants.Call)
                                .Count();
            decimal aggressionFactor = 0;
            if (aggressiveBettingActionsCount != 0 && passiveBettingActionsCount != 0)
            {
                aggressionFactor = aggressiveBettingActionsCount / passiveBettingActionsCount;
            }
            else if (aggressiveBettingActionsCount != 0)
            {
                aggressionFactor = aggressiveBettingActionsCount;
            }
            return aggressionFactor;
        }

        public bool GetFourBet(List<BettingActionDto> playerPreflopBettingActions, string playerName)
        {
            if (playerPreflopBettingActions.Count == 0)
            {
                return false;
            }
            return playerPreflopBettingActions
                            .Where(a => a.Action == BettingActionNamesConstants.Bet || a.Action == BettingActionNamesConstants.Raise)
                            .Skip(2)
                            .Take(1)
                            .Any(p => p.PlayerName == playerName);
        }

        public bool GetThreeBet(List<BettingActionDto> playerPreflopBettingActions, string playerName)
        {
            if (playerPreflopBettingActions.Count == 0)
            {
                return false;
            }
            return playerPreflopBettingActions
                            .Where(a => a.Action == BettingActionNamesConstants.Bet || a.Action == BettingActionNamesConstants.Raise)
                            .Skip(1)
                            .Take(1)
                            .Any(p => p.PlayerName == playerName);
        }

        public bool GetPreFlopRaise(List<BettingActionDto> playerPreflopBettingActions)
        {
            if (playerPreflopBettingActions.Count == 0)
            {
                return false;
            }
            return playerPreflopBettingActions
                            .Any(a => a.Action == BettingActionNamesConstants.Bet || a.Action == BettingActionNamesConstants.Raise);
        }
        public bool GetVoluntaryPutMoneyInPot(List<BettingActionDto> playerPreflopBettingActions)
        {
            if (playerPreflopBettingActions.Count == 0)
            {
                return false;
            }
            return playerPreflopBettingActions
                            .Any(a => a.Action == BettingActionNamesConstants.Call ||
                                 a.Action == BettingActionNamesConstants.Bet ||
                                 a.Action == BettingActionNamesConstants.Raise);
        }
    }
}
