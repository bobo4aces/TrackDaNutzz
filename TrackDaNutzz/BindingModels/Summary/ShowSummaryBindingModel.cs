using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels.Summary
{
    public class ShowSummaryBindingModel
    {
        //private static string ShowSummaryPattern = $@"^Seat ({GlobalConstants.SeatNumberPattern}): ({GlobalConstants.PlayerNamePattern}) ?\(?({GlobalConstants.PositionPattern})?\)? showed \[({GlobalConstants.CardPattern}) ({GlobalConstants.CardPattern})\] and (lost|won) ?(\(({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})\))? with ({GlobalConstants.HandStrengthPattern})$";

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
        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }

        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Value { get; set; }

        [RegularExpression(GlobalConstants.HandStrengthPattern)]
        public string HandStrength { get; set; }
    }
}
