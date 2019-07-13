using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.BindingModels
{
    public class BettingActionsByRoundBindingModel
    {
        public string Round { get; set; }
        public List<BettingActionBindingModel> BettingActionBindingModels { get; set; }
    }
}
