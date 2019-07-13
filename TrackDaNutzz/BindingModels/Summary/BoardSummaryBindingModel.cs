using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels.Summary
{
    public class BoardSummaryBindingModel
    {
        //private static string BoardSummaryPattern = $@"^Board \[({GlobalConstants.CardPattern})? ?({GlobalConstants.CardPattern})? ?({GlobalConstants.CardPattern})? ?({GlobalConstants.CardPattern})? ?({GlobalConstants.CardPattern})?\]$";


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
