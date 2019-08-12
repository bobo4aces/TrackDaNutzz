using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class DealtCardsBindingModel
    {
        //private static string dealtCardsPattern = $@"^Dealt to ({GlobalConstants.PlayerNamePattern}) \[({GlobalConstants.CardPattern}) ({GlobalConstants.CardPattern})\]$";
        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
        [RegularExpression(GlobalConstants.CardPattern)]
        public string FirstCard { get; set; }
        [RegularExpression(GlobalConstants.CardPattern)]
        public string SecondCard { get; set; }
    }
}
