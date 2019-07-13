﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class CollectMoneyBindingModel
    {
        //private static string CollectPattern = $@"^({GlobalConstants.PlayerNamePattern}) collected ({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern}) from pot$";

        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }
        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Value { get; set; }
    }
}
