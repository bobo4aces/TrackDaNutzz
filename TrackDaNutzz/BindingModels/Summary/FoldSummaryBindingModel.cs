using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels.Summary
{
    public class FoldSummaryBindingModel
    {
        //private static string FoldSummaryPattern = $@"^Seat ({GlobalConstants.SeatNumberPattern}): ({GlobalConstants.PlayerNamePattern}) ?\(?({GlobalConstants.PositionPattern})?\)? folded ({GlobalConstants.BeforeOrOnPattern}) ({GlobalConstants.RoundSummaryPattern}) ?({GlobalConstants.DidNotBetPattern})?$";


        [RegularExpression(GlobalConstants.SeatNumberPattern)]
        public int SeatNumber { get; set; }

        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
        [RegularExpression(GlobalConstants.PositionPattern)]
        public string Position { get; set; }
        [RegularExpression(GlobalConstants.BeforeOrOnPattern)]
        public bool IsBeforeRound { get; set; }
        [RegularExpression(GlobalConstants.RoundSummaryPattern)]
        public string Round { get; set; }
        [RegularExpression(GlobalConstants.DidNotBetPattern)]
        public bool DidNotBet { get; set; }
    }
}
