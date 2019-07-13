using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class MuckHandBindingModel
    {
        //private static string MuckHandPattern = $@"^({GlobalConstants.PlayerNamePattern}): (doesn't show hand|mucks hand)$";

        [RegularExpression(GlobalConstants.PlayerNamePattern)]
        public string PlayerName { get; set; }
    }
}
