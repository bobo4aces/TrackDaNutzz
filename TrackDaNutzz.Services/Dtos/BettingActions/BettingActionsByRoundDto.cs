using System.Collections.Generic;

namespace TrackDaNutzz.Services.Dtos.BettingActions
{
    public class BettingActionsByRoundDto
    {
        public string Round { get; set; }
        public List<BettingActionDto> BettingActionDtos { get; set; }
    }
}
