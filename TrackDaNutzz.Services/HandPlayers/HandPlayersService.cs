using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Common.Enums;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Extensions;
using TrackDaNutzz.Services.Helpers;

namespace TrackDaNutzz.Services.HandPlayers
{
    public class HandPlayersService : IHandPlayersService
    {
        private readonly TrackDaNutzzDbContext context;

        public HandPlayersService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

        public bool AddHandPlayer(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, SeatInfoDto seatInfoDto, Player player)
        {
            //TODO: Use Automapper
            HandPlayer handPlayer = this.context.HandPlayers.SingleOrDefault(x => x.HandId == handId && x.PlayerId == player.Id);
            if (handPlayer != null)
            {
                return false;
            }
            decimal finalStack = Stack.CalculateFinalStack(handDto, seatInfoDto);
            handPlayer = new HandPlayer()
            {
                HandId = handId,
                Player = player,
                HasShowdown = handDto.ShowCardsListDto.ShowCardsDtos.Any(x => x.PlayerName == seatInfoDto.PlayerName),
                HoleCards = this.GetHoleCards(handDto, seatInfoDto),
                FinalStack = finalStack,
                IsAllIn = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                .Any(x => x.BettingActionDtos.Where(y => y.PlayerName == seatInfoDto.PlayerName).Any(z => z.IsAllIn.Value == true)),
                IsMuckCards = handDto.MuckHandListDto.MuckHandDtos.Any(x => x.PlayerName == seatInfoDto.PlayerName),
                SeatNumber = seatInfoDto.SeatNumber,
                StartingStack = seatInfoDto.Money,
                StackDifference = finalStack - seatInfoDto.Money,
                StatisticId = statisticsIdsByPlayerName[seatInfoDto.PlayerName]
            };
            this.context.HandPlayers.Add(handPlayer);
            this.context.SaveChanges();

            return true;
        }

        public bool AddBettingActionIdSplitByPipe(long bettingActionId, long handId, int playerId)
        {
            HandPlayer handPlayer = this.context.HandPlayers
                        .FirstOrDefault(x => x.HandId == handId && x.PlayerId == playerId);
            if (handPlayer == null)
            {
                return false;
            }
            handPlayer.BettingActionIds.Add(bettingActionId);
            return true;
        }

        public IQueryable<long> GetAllHandIdsByPlayer(int playerId)
        {
            IQueryable<long> handIds = this.context.HandPlayers.Where(x => x.PlayerId == playerId).Select(x => x.HandId);

            return handIds;
        }

        public IQueryable<long> GetStatisticIdsByPlayerIdAndHandId(int playerId, params long[] handIds)
        {
            IQueryable<long> statisticsIds = this.context.HandPlayers
                .Where(x => x.PlayerId == playerId && handIds.Contains(x.HandId))
                .Select(x => x.StatisticId);
            return statisticsIds;
        }

        public IQueryable<int> GetAllPlayerIdsByHandId(params long[] handIds)
        {
            IQueryable<int> playerIds = this.context.HandPlayers.Where(x => handIds.Contains(x.HandId)).Select(x => x.PlayerId);
            return playerIds;
        }

        public decimal GetWinnings(int playerId, WinningsType winningsType, TotalAverage totalOrAverage, TimePeriod timePeriod, int timePeriodCount)
        {
            //TODO: Don't use Statistic and Hand
            DateTime fromDate = DateTime.UtcNow.Before(timePeriod, timePeriodCount);
            decimal winnings = 0;
            if (winningsType == WinningsType.BigBlinds)
            {
                winnings = this.context.HandPlayers
                    .Where(x => x.PlayerId == playerId && x.Hand.Time.CompareTo(fromDate) == 1)
                    .Sum(x => x.Statistic.BigBlindsWon);
            }
            else if (winningsType == WinningsType.Money)
            {
                winnings = this.context.HandPlayers
                    .Where(x => x.PlayerId == playerId && x.Hand.Time.CompareTo(fromDate) == 1)
                    .Sum(x => x.Statistic.MoneyWon);
            }
            if (totalOrAverage == TotalAverage.Average)
            {
                long handsCount = this.context.HandPlayers
                .Where(x => x.PlayerId == playerId && x.Hand.Time.CompareTo(fromDate) == -1)
                .Count();
                winnings = MathOperations.Divide(winnings, handsCount);
            }

            return winnings;
        }
        private string GetHoleCards(ImportHandDto handDto, SeatInfoDto seatInfoDto)
        {
            var cards = handDto.ShowCardsListDto.ShowCardsDtos
                                                .Where(x => x.PlayerName == seatInfoDto.PlayerName)
                                                .Select(x => new { x.FirstCard, x.SecondCard })
                                                .ToList();
            string holeCards = null;
            if (cards.Count > 0)
            {
                holeCards = $"{cards[0].FirstCard} {cards[0].SecondCard}";
            }
            return holeCards;
        }
    }
}
