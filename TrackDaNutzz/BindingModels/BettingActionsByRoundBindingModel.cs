using System.Collections.Generic;

namespace TrackDaNutzz.BindingModels
{
    public class BettingActionsByRoundBindingModel
    {
        public string Round { get; set; }
        public List<BettingActionBindingModel> BettingActionBindingModels { get; set; }
    }
}
