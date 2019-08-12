using TrackDaNutzz.BindingModels.Summary;

namespace TrackDaNutzz.BindingModels
{
    public class HandBindingModel
    {
        public HandInfoBindingModel HandInfoBindingModel { get; set; }
        public TableBindingModel TableBindingModel { get; set; }
        public SeatInfoListBindingModel SeatInfoListBindingModel { get; set; }
        public BettingActionsByRoundListBindingModel BettingActionsByRoundListBindingModel { get; set; }
        public DealtCardsBindingModel DealtCardsBindingModel { get; set; }
        public RoundListBindingModel RoundListBindingModel { get; set; }
        public ShowCardsListBindingModel ShowCardsListBindingModel { get; set; }
        public UncalledBetsListBindingModel UncalledBetsListBindingModel { get; set; }
        public MuckHandListBindingModel MuckHandListBindingModel { get; set; }
        public CollectMoneyListBindingModel CollectMoneyListBindingModel { get; set; }
        public PotRakeSummaryBindingModel PotRakeSummaryBindingModel { get; set; }
        public BoardSummaryBindingModel BoardSummaryBindingModel { get; set; }
        public FoldSummaryListBindingModel FoldSummaryListBindingModel { get; set; }
        public MuckSummaryListBindingModel MuckSummaryListBindingModel { get; set; }
        public CollectSummaryListBindingModel CollectSummaryListBindingModel { get; set; }
        public ShowSummaryListBindingModel ShowSummaryListBindingModel { get; set; }
    }
}
