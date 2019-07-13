using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels.Summary
{
    public class CollectSummaryBindingModel
    {
        //private static string CollectSummaryPattern = $@"^Seat ({GlobalConstants.SeatNumberPattern}): ({GlobalConstants.PlayerNamePattern}) ?\(?({GlobalConstants.PositionPattern})?\)? collected \(({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})\)$";

        [RegularExpression(GlobalConstants.SeatNumberPattern)]
        public int SeatNumber { get; set; }

        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }

        [RegularExpression(GlobalConstants.PositionPattern)]
        public string Position { get; set; }

        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }

        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Value { get; set; }
    }
}
