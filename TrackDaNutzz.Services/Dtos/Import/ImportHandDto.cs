using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.DealtCards;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Rounds;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.Dtos.UncalledBets;

namespace TrackDaNutzz.Services.Dtos.Import
{
    public class ImportHandDto
    {
        public HandInfoDto HandInfoDto { get; set; }
        public ImportTableDto ImportTableDto { get; set; }
        public SeatInfoListDto SeatInfoListDto { get; set; }
        public BettingActionsByRoundListDto BettingActionsByRoundListDto { get; set; }
        public DealtCardsDto DealtCardsDto { get; set; }
        public RoundListDto RoundListDto { get; set; }
        public ShowCardsListDto ShowCardsListDto { get; set; }
        public UncalledBetsListDto UncalledBetsListDto { get; set; }
        public MuckHandListDto MuckHandListDto { get; set; }
        public CollectMoneyListDto CollectMoneyListDto { get; set; }
        public PotRakeSummaryDto PotRakeSummaryDto { get; set; }
        public BoardSummaryDto BoardSummaryDto { get; set; }
        public FoldSummaryListDto FoldSummaryListDto { get; set; }
        public MuckSummaryListDto MuckSummaryListDto { get; set; }
        public CollectSummaryListDto CollectSummaryListDto { get; set; }
        public ShowSummaryListDto ShowSummaryListDto { get; set; }
    }
}
