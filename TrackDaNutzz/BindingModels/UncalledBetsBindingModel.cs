using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class UncalledBetsBindingModel
    {
        //private static string UncalledBetPattern = $@"^Uncalled bet \(({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})\) returned to ({GlobalConstants.PlayerNamePattern})$";

        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }
        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Value { get; set; }
        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
    }
}
