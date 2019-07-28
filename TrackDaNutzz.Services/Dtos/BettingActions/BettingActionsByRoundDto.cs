using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.BettingActions
{
    public class BettingActionsByRoundDto
    {
        public string Round { get; set; }
        public List<BettingActionDto> BettingActionDtos { get; set; }
    }
}
