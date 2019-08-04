using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.HandPlayers;

namespace TrackDaNutzz.Services.Hands
{
    public class HandsService : IHandsService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IHandPlayersService handPlayersService;

        public HandsService(TrackDaNutzzDbContext context, IHandPlayersService handPlayersService)
        {
            this.context = context;
            this.handPlayersService = handPlayersService;
        }
        public long AddHand(ImportHandDto handDto, long? boardId, int tableId)
        {
            //TODO: Use Automapper
            Hand hand = this.context.Hands.SingleOrDefault(h => h.Number == handDto.HandInfoDto.HandNumber);
            if (hand != null)
            {
                return hand.Id;
            }
            hand = new Hand()
            {
                LocalTime = handDto.HandInfoDto.LocalTime,
                LocalTimeZone = handDto.HandInfoDto.LocalTimeZone,
                Number = handDto.HandInfoDto.HandNumber,
                Time = handDto.HandInfoDto.Time,
                TimeZone = handDto.HandInfoDto.TimeZone,
                BoardId = boardId,
                Button = handDto.ImportTableDto.ButtonSeat,
                Pot = handDto.PotRakeSummaryDto.Pot,
                Rake = handDto.PotRakeSummaryDto.Rake,
                TableId = tableId
            };
            this.context.Hands.Add(hand);
            this.context.SaveChanges();
            return hand.Id;
        }

        public IQueryable<long> GetHandIdsByTableId(params int[] tableIds)
        {
            IQueryable<long> handIds = this.context.Hands
                .Where(h => tableIds.Contains(h.TableId))
                .Select(h => h.Id);
            return handIds;
        }

        public IQueryable<int> GetTableIdsByHandId(params long[] handIds)
        {
            IQueryable<int> tableIds = this.context.Hands
                .Where(h => handIds.Contains(h.Id))
                .Select(h => h.TableId);
            return tableIds;
        }

        public IQueryable<HandDto> GetAllHandsByPlayerId(int playerId)
        {
            //TODO: Use Automapper
            HashSet<long> handIds = this.handPlayersService.GetAllHandIdsByPlayer(playerId).ToHashSet();
            IQueryable<HandDto> handDtos = this.context.Hands
                .Where(h => handIds.Contains(h.Id))
                .Select(h => new HandDto
                {
                    BoardId = h.BoardId,
                    Button = h.Button,
                    Id = h.Id,
                    LocalTime = h.LocalTime,
                    LocalTimeZone = h.LocalTimeZone,
                    Number = h.Number,
                    Pot = h.Pot,
                    Rake = h.Rake,
                    TableId = h.TableId,
                    Time = h.Time,
                    TimeZone = h.TimeZone,

                });
            return handDtos;
        }
    }
}
