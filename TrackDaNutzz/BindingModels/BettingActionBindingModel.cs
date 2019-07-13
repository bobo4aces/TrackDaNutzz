using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class BettingActionBindingModel
    {
        //private static string bettingActionsPattern = $@"^({GlobalConstants.PlayerNamePattern}): ({GlobalConstants.ActionPattern}) ?({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})?( to )?({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})?({GlobalConstants.IsAllInPattern})?$";

        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
        [RegularExpression(GlobalConstants.ActionPattern)]
        public string Action { get; set; }
        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }
        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal? Value { get; set; }
        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal? RaiseTo { get; set; }
        [RegularExpression(GlobalConstants.IsAllInPattern)]
        public bool? IsAllIn { get; set; }
    }
}
