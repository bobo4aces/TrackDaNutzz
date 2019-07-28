using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Tables;

namespace TrackDaNutzz.Services.Hands
{
    public class HandsService : IHandsService
    {
        private readonly TrackDaNutzzDbContext context;

        public HandsService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }
        public long AddHand(HandDto handDto, long? boardId, int tableId)
        {
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
                Button = handDto.TableDto.ButtonSeat,
                Pot = handDto.PotRakeSummaryDto.Pot,
                Rake = handDto.PotRakeSummaryDto.Rake,
                TableId = tableId
            };
            this.context.Hands.Add(hand);
            this.context.SaveChanges();
            return hand.Id;
        }
    }
}
