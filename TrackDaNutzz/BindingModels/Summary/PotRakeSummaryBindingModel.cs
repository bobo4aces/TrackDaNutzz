using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels.Summary
{
    public class PotRakeSummaryBindingModel
    {
        //private static string PotRakeSummaryPattern = $@"^Total pot ({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern}) \| Rake ({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})$";

        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }

        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Pot { get; set; }

        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Rake { get; set; }
    }
}
