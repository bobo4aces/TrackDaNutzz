using System.ComponentModel.DataAnnotations;
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
