using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.BindingModels;
using TrackDaNutzz.BindingModels.Summary;
using TrackDaNutzz.Common;
using TrackDaNutzz.Extensions;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Import;

namespace TrackDaNutzz.Parsers
{
    public class PokerStarsParser : IParser
    {
        private readonly IMapper mapper;
        private readonly IImportService importService;

        public PokerStarsParser(IMapper mapper, IImportService importService)
        {
            this.mapper = mapper;
            this.importService = importService;
        }
        public int ParseHandHistory(IEnumerable<string> handHistory)
        {
            int parsedHands = 0;
            int start = 0;
            while (start < handHistory.Count())
            {
                string[] hand = handHistory.Skip(start).TakeWhile(e => e.Length > 0).ToArray();
                if (hand.Length == 0)
                {
                    break;
                }
                string[] currentHand = hand
                    .Select(r => r.Trim())
                    .Where(
                    r => !r.Contains("leaves the table") &&
                    !r.Contains("joins the table at seat") &&
                    !r.Contains("will be allowed to play after the button") &&
                    !r.Contains("sits out") &&
                    !r.Contains("sitting out") &&
                    !r.Contains("has timed out")
                    ).ToArray();
                ParseHand(currentHand);
                parsedHands++;
                start += hand.Length + GlobalConstants.EmptyRowsCount;
            }
            return parsedHands;
        }
        private void ParseHand(string[] hand)
        {
            int index = 0;
            Dictionary<string, string> handValues = hand[index++].GetGroups(PokerStarsRows.HandRow);
            HandInfoBindingModel handInfoBindingModel = this.mapper.Map<HandInfoBindingModel>(handValues);

            Dictionary<string, string> tableValues = hand[index++].GetGroups(PokerStarsRows.TableRow);
            TableBindingModel tableBindingModel = this.mapper.Map<TableBindingModel>(tableValues);

            List<SeatInfoBindingModel> seatInfoBindingModels = new List<SeatInfoBindingModel>();
            while (hand[index].IsValid(PokerStarsRows.SeatInfoRow))
            {
                Dictionary<string, string> seatInfoValues = hand[index].GetGroups(PokerStarsRows.SeatInfoRow);
                SeatInfoBindingModel seatInfoBindingModel = this.mapper.Map<SeatInfoBindingModel>(seatInfoValues);
                seatInfoBindingModels.Add(seatInfoBindingModel);
                index++;
            }
            SeatInfoListBindingModel seatInfoListBindingModel = this.mapper.Map<SeatInfoListBindingModel>(seatInfoBindingModels);
            string round = GlobalConstants.PreflopRound;

            Dictionary<string, List<BettingActionBindingModel>> bettingActionsByRound = new Dictionary<string, List<BettingActionBindingModel>>();
            index = ParseBettingActions(hand, index, round, PokerStarsRows.BettingActionRow, bettingActionsByRound);
            if (hand[index] == GlobalConstants.PreflopRow)
            {
                index++;
            }
            Dictionary<string, string> dealtCards = hand[index++].GetGroups(PokerStarsRows.DealtCardsRow);
            DealtCardsBindingModel dealtCardsBindingModel = this.mapper.Map<DealtCardsBindingModel>(dealtCards);
            index = ParseBettingActions(hand, index, round, PokerStarsRows.BettingActionRow, bettingActionsByRound);

            List<RoundBindingModel> roundBindingModels = new List<RoundBindingModel>();
            List<UncalledBetsBindingModel> uncalledBetsBindingModels = new List<UncalledBetsBindingModel>();
            while (hand[index].IsValid(PokerStarsRows.RoundRow))
            {
                Dictionary<string, string> roundValues = hand[index++].GetGroups(PokerStarsRows.RoundRow);
                RoundBindingModel roundBindingModel = this.mapper.Map<RoundBindingModel>(roundValues);
                roundBindingModels.Add(roundBindingModel);
                index = ParseBettingActions(hand, index, roundBindingModel.RoundName, PokerStarsRows.BettingActionRow, bettingActionsByRound);
                if (hand[index].IsValid(PokerStarsRows.UncalledBetsRow))
                {
                    uncalledBetsBindingModels.AddRange(this.GetUncalledBets(hand, ref index));
                    continue;
                }
            }
            RoundListBindingModel roundListBindingModel = this.mapper.Map<RoundListBindingModel>(roundBindingModels);
            ///
            List<BettingActionsByRoundBindingModel> bettingActionsByRoundBindingModels = new List<BettingActionsByRoundBindingModel>();
            foreach (var currentRound in bettingActionsByRound)
            {
                BettingActionsByRoundBindingModel bettingActionsByRoundBindingModel = this.mapper.Map<BettingActionsByRoundBindingModel>(currentRound);
                bettingActionsByRoundBindingModels.Add(bettingActionsByRoundBindingModel);
            }
            BettingActionsByRoundListBindingModel bettingActionsByRoundListBindingModel = this.mapper.Map<BettingActionsByRoundListBindingModel>(bettingActionsByRoundBindingModels);
            List<ShowCardsBindingModel> showCardsBindingModels = new List<ShowCardsBindingModel>();
            List<MuckHandBindingModel> muckHandBindingModels = new List<MuckHandBindingModel>();
            List<CollectMoneyBindingModel> collectMoneyBindingModels = new List<CollectMoneyBindingModel>();
            if (hand[index] == GlobalConstants.ShowdownRow)
            {
                index++;
            }
            while (hand[index] != GlobalConstants.SummaryRow)
            {
                if (hand[index].IsValid(PokerStarsRows.ShowCardsRow))
                {
                    showCardsBindingModels.AddRange(this.GetShowCards(hand, ref index));
                }
                else if (hand[index].IsValid(PokerStarsRows.MuckHandRow))
                {
                    muckHandBindingModels.AddRange(this.GetMuckHands(hand, ref index));
                }
                else if (hand[index].IsValid(PokerStarsRows.CollectMoneyRow))
                {
                    collectMoneyBindingModels.AddRange(this.GetCollectMoney(hand, ref index));
                }
                else if (hand[index].IsValid(PokerStarsRows.UncalledBetsRow))
                {
                    uncalledBetsBindingModels.AddRange(this.GetUncalledBets(hand, ref index));
                }
                else
                {
                    throw new ArgumentException($"Invalid hand row - row: \"{hand[index]}\"");
                }
            }
            ShowCardsListBindingModel showCardsListBindingModel = this.mapper.Map<ShowCardsListBindingModel>(showCardsBindingModels);

            UncalledBetsListBindingModel uncalledBetsListBindingModel = this.mapper.Map<UncalledBetsListBindingModel>(uncalledBetsBindingModels);

            CollectMoneyListBindingModel collectMoneyListBindingModel = this.mapper.Map<CollectMoneyListBindingModel>(collectMoneyBindingModels);
            //muckHandBindingModels.AddRange(this.GetMuckHands(hand, ref index));
            MuckHandListBindingModel muckHandListBindingModel = this.mapper.Map<MuckHandListBindingModel>(muckHandBindingModels);
            if (hand[index] == GlobalConstants.SummaryRow)
            {
                index++;
            }

            Dictionary<string, string> potRakeSummaryValues = hand[index++].GetGroups(PokerStarsRows.PotRakeSummaryRow);
            PotRakeSummaryBindingModel potRakeSummaryBindingModel = this.mapper.Map<PotRakeSummaryBindingModel>(potRakeSummaryValues);

            BoardSummaryBindingModel boardSummaryBindingModel = new BoardSummaryBindingModel();

            if (hand[index].IsValid(PokerStarsRows.BoardSummaryRow))
            {
                Dictionary<string, string> boardSummaryValues = hand[index++].GetGroups(PokerStarsRows.BoardSummaryRow);
                boardSummaryBindingModel = this.mapper.Map<BoardSummaryBindingModel>(boardSummaryValues);
            }

            List<FoldSummaryBindingModel> foldSummaryBindingModels = new List<FoldSummaryBindingModel>();
            List<MuckSummaryBindingModel> muckSummaryBindingModels = new List<MuckSummaryBindingModel>();
            List<CollectSummaryBindingModel> collectSummaryBindingModels = new List<CollectSummaryBindingModel>();
            List<ShowSummaryBindingModel> showSummaryBindingModels = new List<ShowSummaryBindingModel>();
            while (index < hand.Length)
            {
                if (hand[index].IsValid(PokerStarsRows.FoldSummaryRow))
                {
                    Dictionary<string, string> foldSummaryValues = hand[index++].GetGroups(PokerStarsRows.FoldSummaryRow);
                    FoldSummaryBindingModel foldSummaryBindingModel = this.mapper.Map<FoldSummaryBindingModel>(foldSummaryValues);
                    foldSummaryBindingModels.Add(foldSummaryBindingModel);
                }
                else if (hand[index].IsValid(PokerStarsRows.MuckSummaryRow))
                {
                    Dictionary<string, string> muckSummaryRowValues = hand[index++].GetGroups(PokerStarsRows.MuckSummaryRow);
                    MuckSummaryBindingModel muckSummaryBindingModel = this.mapper.Map<MuckSummaryBindingModel>(muckSummaryRowValues);
                    muckSummaryBindingModels.Add(muckSummaryBindingModel);
                }
                else if (hand[index].IsValid(PokerStarsRows.CollectSummaryRow))
                {
                    Dictionary<string, string> collectSummaryRowValues = hand[index++].GetGroups(PokerStarsRows.CollectSummaryRow);
                    CollectSummaryBindingModel collectSummaryBindingModel = this.mapper.Map<CollectSummaryBindingModel>(collectSummaryRowValues);
                    collectSummaryBindingModels.Add(collectSummaryBindingModel);
                }
                else if (hand[index].IsValid(PokerStarsRows.ShowSummaryRow))
                {
                    Dictionary<string, string> showSummaryRowValues = hand[index++].GetGroups(PokerStarsRows.ShowSummaryRow);
                    ShowSummaryBindingModel showSummaryBindingModel = this.mapper.Map<ShowSummaryBindingModel>(showSummaryRowValues);
                    showSummaryBindingModels.Add(showSummaryBindingModel);
                }
                else
                {
                    throw new FormatException("Invalid hand format");
                }
            }
            FoldSummaryListBindingModel foldSummaryListBindingModel = this.mapper.Map<FoldSummaryListBindingModel>(foldSummaryBindingModels);
            MuckSummaryListBindingModel muckSummaryListBindingModel = this.mapper.Map<MuckSummaryListBindingModel>(muckSummaryBindingModels);
            CollectSummaryListBindingModel collectSummaryListBindingModel = this.mapper.Map<CollectSummaryListBindingModel>(collectSummaryBindingModels);
            ShowSummaryListBindingModel showSummaryListBindingModel = this.mapper.Map<ShowSummaryListBindingModel>(showSummaryBindingModels);
            HandBindingModel handBindingModel = new HandBindingModel
            {
                BettingActionsByRoundListBindingModel = bettingActionsByRoundListBindingModel,
                BoardSummaryBindingModel = boardSummaryBindingModel,
                CollectMoneyListBindingModel = collectMoneyListBindingModel,
                CollectSummaryListBindingModel = collectSummaryListBindingModel,
                DealtCardsBindingModel = dealtCardsBindingModel,
                FoldSummaryListBindingModel = foldSummaryListBindingModel,
                HandInfoBindingModel = handInfoBindingModel,
                MuckHandListBindingModel = muckHandListBindingModel,
                MuckSummaryListBindingModel = muckSummaryListBindingModel,
                PotRakeSummaryBindingModel = potRakeSummaryBindingModel,
                RoundListBindingModel = roundListBindingModel,
                SeatInfoListBindingModel = seatInfoListBindingModel,
                ShowCardsListBindingModel = showCardsListBindingModel,
                ShowSummaryListBindingModel = showSummaryListBindingModel,
                TableBindingModel = tableBindingModel,
                UncalledBetsListBindingModel = uncalledBetsListBindingModel
            };
            ImportHandDto handDto = this.mapper.Map<ImportHandDto>(handBindingModel);
            this.importService.Add(handDto);
        }

        private List<CollectMoneyBindingModel> GetCollectMoney(string[] hand, ref int index)
        {
            List<CollectMoneyBindingModel> collectMoneyBindingModels = new List<CollectMoneyBindingModel>();
            while (hand[index].IsValid(PokerStarsRows.CollectMoneyRow))
            {
                Dictionary<string, string> collectMoneyValues = hand[index++].GetGroups(PokerStarsRows.CollectMoneyRow);
                CollectMoneyBindingModel collectMoneyBindingModel = this.mapper.Map<CollectMoneyBindingModel>(collectMoneyValues);
                collectMoneyBindingModels.Add(collectMoneyBindingModel);
            }

            return collectMoneyBindingModels;
        }

        private List<MuckHandBindingModel> GetMuckHands(string[] hand, ref int index)
        {
            List<MuckHandBindingModel> muckHandBindingModels = new List<MuckHandBindingModel>();
            while (hand[index].IsValid(PokerStarsRows.MuckHandRow))
            {
                Dictionary<string, string> muckHandValues = hand[index++].GetGroups(PokerStarsRows.MuckHandRow);
                MuckHandBindingModel muckHandBindingModel = this.mapper.Map<MuckHandBindingModel>(muckHandValues);
                muckHandBindingModels.Add(muckHandBindingModel);
            }
            return muckHandBindingModels;
        }

        private List<UncalledBetsBindingModel> GetUncalledBets(string[] hand, ref int index)
        {
            List<UncalledBetsBindingModel> uncalledBetsBindingModels = new List<UncalledBetsBindingModel>();
            while (hand[index].IsValid(PokerStarsRows.UncalledBetsRow))
            {
                Dictionary<string, string> uncalledBetsValues = hand[index++].GetGroups(PokerStarsRows.UncalledBetsRow);
                UncalledBetsBindingModel uncalledBetsBindingModel = this.mapper.Map<UncalledBetsBindingModel>(uncalledBetsValues);
                uncalledBetsBindingModels.Add(uncalledBetsBindingModel);
            }

            return uncalledBetsBindingModels;
        }

        private List<ShowCardsBindingModel> GetShowCards(string[] hand, ref int index)
        {
            List<ShowCardsBindingModel> showCardsBindingModels = new List<ShowCardsBindingModel>();
            while (hand[index].IsValid(PokerStarsRows.ShowCardsRow))
            {
                Dictionary<string, string> showCardsValues = hand[index++].GetGroups(PokerStarsRows.ShowCardsRow);
                ShowCardsBindingModel showCardsBindingModel = this.mapper.Map<ShowCardsBindingModel>(showCardsValues);
                showCardsBindingModels.Add(showCardsBindingModel);
            }

            return showCardsBindingModels;
        }

        private int ParseBettingActions(string[] hand, int index, string round, string row, Dictionary<string, List<BettingActionBindingModel>> bettingActionsByRound)
        {
            while (hand[index].IsValid(row))
            {
                Dictionary<string, string> bettingActions = hand[index].GetGroups(row);
                BettingActionBindingModel bettingActionBindingModel = this.mapper.Map<BettingActionBindingModel>(bettingActions);
                if (!bettingActionsByRound.ContainsKey(round))
                {
                    bettingActionsByRound.Add(round, new List<BettingActionBindingModel>());
                }
                bettingActionsByRound[round].Add(bettingActionBindingModel);
                index++;
            }

            return index;
        }
    }
}
