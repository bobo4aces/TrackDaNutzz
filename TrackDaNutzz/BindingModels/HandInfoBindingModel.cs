using System;
using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class HandInfoBindingModel
    {
        //public string FirstRow => $@"^({GlobalConstants.ClientNamePattern}) Hand #({GlobalConstants.HandNumberPattern}):\s\s({GlobalConstants.VariantNamePattern}) ({GlobalConstants.LimitPattern}) \(({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern})\/({GlobalConstants.CurrencySymbolPattern})?({GlobalConstants.MoneyPattern}) ?({GlobalConstants.CurrencyPattern})?\) - ({GlobalConstants.TimePattern}) \[({GlobalConstants.TimePattern})\]$";

        [RegularExpression(GlobalConstants.ClientNamePattern)]
        public string ClientName { get; set; }
        [RegularExpression(GlobalConstants.HandNumberPattern)]
        public long HandNumber { get; set; }
        [RegularExpression(GlobalConstants.VariantNamePattern)]
        public string VariantName { get; set; }
        [RegularExpression(GlobalConstants.TableNamePattern)]

        public string Limit { get; set; }
        [RegularExpression(GlobalConstants.CurrencySymbolPattern)]
        public string CurrencySymbol { get; set; }
        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal SmallBlind { get; set; }

        [RegularExpression(GlobalConstants.MoneyPattern)]
        public decimal BigBlind { get; set; }

        [RegularExpression(GlobalConstants.CurrencyPattern)]
        public string Currency { get; set; }
        [RegularExpression(GlobalConstants.TimePattern)]
        public DateTime Time { get; set; }

        [RegularExpression(GlobalConstants.TimeZonePattern)]
        public string TimeZone { get; set; }

        [RegularExpression(GlobalConstants.TimePattern)]
        public DateTime LocalTime { get; set; }

        [RegularExpression(GlobalConstants.TimeZonePattern)]
        public string LocalTimeZone { get; set; }
    }
}
