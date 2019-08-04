using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;
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

        public bool AddBettingAction(long bettingActionId, long handId, int playerId)
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
        private decimal CalculateFinalStack(ImportHandDto handDto, SeatInfoDto seatInfoDto)
        {
            decimal betMoney = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                        .SelectMany(x => x.BettingActionDtos
                                    .Where(y => y.PlayerName == seatInfoDto.PlayerName && y.Value.HasValue)
                                    .Select(z => z.RaiseTo.HasValue ? z.RaiseTo.Value : z.Value.Value)
                        .ToList())
                        .ToList()
                        .Sum();
            decimal collectedMoney = handDto.CollectMoneyListDto.CollectMoneyDtos
                        .Where(x => x.PlayerName == seatInfoDto.PlayerName)
                        .Sum(x => x.Value);
            return seatInfoDto.Money - betMoney + collectedMoney;
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
