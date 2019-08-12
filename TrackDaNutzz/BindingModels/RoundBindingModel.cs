using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class RoundBindingModel
    {
        //private static string streetPattern = $@"^\*\*\* ({GlobalConstants.RoundPattern}) \*\*\* \[({GlobalConstants.CardPattern}) ({GlobalConstants.CardPattern}) ({GlobalConstants.CardPattern})\]? ?\[?({GlobalConstants.CardPattern})?\]? ?\[?({GlobalConstants.CardPattern})?\]$";
        [RegularExpression(GlobalConstants.RoundPattern)]
        public string RoundName { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string FirstCard { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string SecondCard { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string ThirdCard { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string FourthCard { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string FifthCard { get; set; }

    }
}
