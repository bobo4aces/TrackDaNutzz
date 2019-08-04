using System.Linq;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;

namespace TrackDaNutzz.Services.Helpers
{
    public class Stack
    {
        public static decimal CalculateFinalStack(ImportHandDto handDto, SeatInfoDto seatInfoDto)
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
    }
}
