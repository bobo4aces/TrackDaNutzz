using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels.Summary
{
    public class MuckSummaryBindingModel
    {
        //private static string MuckSummaryPattern = $@"^Seat ({GlobalConstants.SeatNumberPattern}): ({GlobalConstants.PlayerNamePattern}) ?\(?({GlobalConstants.PositionPattern})?\)? mucked \[({GlobalConstants.CardPattern}) ({GlobalConstants.CardPattern})\]$";

        [RegularExpression(GlobalConstants.SeatNumberPattern)]
        public int SeatNumber { get; set; }

        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }

        [RegularExpression(GlobalConstants.PositionPattern)]
        public string Position { get; set; }
        [RegularExpression(GlobalConstants.CardPattern)]
        public string FirstCard { get; set; }
        [RegularExpression(GlobalConstants.CardPattern)]
        public string SecondCard { get; set; }

    }
}
