using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class ShowCardsBindingModel
    {
        //private static string ShowCardsPattern = $@"^({GlobalConstants.PlayerNamePattern}): shows \[({GlobalConstants.CardPattern}) ({GlobalConstants.CardPattern})\] \(({GlobalConstants.HandStrengthPattern})\)$";
        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string FirstCard { get; set; }

        [RegularExpression(GlobalConstants.CardPattern)]
        public string SecondCard { get; set; }

        [RegularExpression(GlobalConstants.HandStrengthPattern)]
        public string HandStrength { get; set; }
    }
}
