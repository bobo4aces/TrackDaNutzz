using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class SeatInfoBindingModel
    {
        //private string seatInfoPattern = $@"^Seat ({GlobalConstants.SeatNumberPattern}): ({GlobalConstants.PlayerNamePattern}) \(({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern}) in chips\)$";

        [RegularExpression(GlobalConstants.SeatNumberPattern)]
        public int SeatNumber { get; set; }
        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }
        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal Money { get; set; }
    }
}
