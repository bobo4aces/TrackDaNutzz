using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackDaNutzz.BindingModels.Summary;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.DealtCards;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Rounds;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.Dtos.UncalledBets;

namespace TrackDaNutzz.BindingModels
{
    public class HandProfile : Profile
    {
        private decimal temp;
        public HandProfile()
        {

            this.CreateMap<Dictionary<string, string>, HandInfoBindingModel>()
                .ForMember(x => x.ClientName, y => y.MapFrom(z => z["ClientName"]))
                .ForMember(x => x.HandNumber, y => y.MapFrom(z => long.Parse(z["HandNumber"])))
                .ForMember(x => x.VariantName, y => y.MapFrom(z => z["VariantName"]))
                .ForMember(x => x.Limit, y => y.MapFrom(z => z["Limit"]))
                .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
                .ForMember(x => x.SmallBlind, y => y.MapFrom(z => decimal.Parse(z["SmallBlind"])))
                .ForMember(x => x.BigBlind, y => y.MapFrom(z => decimal.Parse(z["BigBlind"])))
                .ForMember(x => x.Time, y => y.MapFrom(z => DateTime.Parse(z["Time"])))
                .ForMember(x => x.TimeZone, y => y.MapFrom(z => z["TimeZone"]))
                .ForMember(x => x.LocalTime, y => y.MapFrom(z => DateTime.Parse(z["LocalTime"])))
                .ForMember(x => x.LocalTimeZone, y => y.MapFrom(z => z["LocalTimeZone"]));
                
            this.CreateMap<Dictionary<string, string>, TableBindingModel>()
                .ForMember(x => x.TableName, y => y.MapFrom(z => z["TableName"]))
                .ForMember(x => x.TableSize, y => y.MapFrom(z => z["TableSize"]))
                .ForMember(x => x.PlayMoney, y => y.MapFrom(z => z["PlayMoney"] == "" ? false : true))
                .ForMember(x => x.ButtonSeat, y => y.MapFrom(z => z["ButtonSeat"]));

            this.CreateMap<Dictionary<string, string>, BettingActionBindingModel>()
                .ForMember(x => x.Action, y => y.MapFrom(z => z["Action"]))
                .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
                .ForMember(x => x.IsAllIn, y => y.MapFrom(z => z["IsAllIn"] == "" ? false : true))
                .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
                .ForMember(x => x.RaiseTo, y => y.MapFrom(z => decimal.TryParse(z["RaiseTo"], out temp) ? temp : (decimal?)null))
                .ForMember(x => x.Value, y => y.MapFrom(z => decimal.TryParse(z["Value"], out temp) ? temp : (decimal?)null));

            this.CreateMap<Dictionary<string, string>, SeatInfoBindingModel>()
                .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
                .ForMember(x => x.Money, y => y.MapFrom(z => decimal.Parse(z["Money"])))
                .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
                .ForMember(x => x.SeatNumber, y => y.MapFrom(z => int.Parse(z["SeatNumber"])));

            this.CreateMap<List<SeatInfoBindingModel>, SeatInfoListBindingModel>()
                .ForMember(x => x.SeatInfoBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, DealtCardsBindingModel>()
                .ForMember(x => x.FirstCard, y => y.MapFrom(z => z["FirstCard"]))
                .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
                .ForMember(x => x.SecondCard, y => y.MapFrom(z => z["SecondCard"]));

            this.CreateMap<Dictionary<string, string>, RoundBindingModel>()
                .ForMember(x => x.FifthCard, y => y.MapFrom(z => z["FifthCard"]))
                .ForMember(x => x.FirstCard, y => y.MapFrom(z => z["FirstCard"]))
                .ForMember(x => x.FourthCard, y => y.MapFrom(z => z["FourthCard"]))
                .ForMember(x => x.RoundName, y => y.MapFrom(z => z["RoundName"]))
                .ForMember(x => x.SecondCard, y => y.MapFrom(z => z["SecondCard"]))
                .ForMember(x => x.ThirdCard, y => y.MapFrom(z => z["ThirdCard"]));

            this.CreateMap<List<RoundBindingModel>, RoundListBindingModel>()
                .ForMember(x => x.RoundBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<KeyValuePair<string, List<BettingActionBindingModel>>, BettingActionsByRoundBindingModel>()
                .ForMember(x => x.Round, y => y.MapFrom(z => z.Key))
                .ForMember(x => x.BettingActionBindingModels, y => y.MapFrom(z => z.Value));

            this.CreateMap<List<BettingActionsByRoundBindingModel>, BettingActionsByRoundListBindingModel>()
                .ForMember(x => x.BettingActionsByRoundBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, ShowCardsBindingModel>()
                .ForMember(x => x.FirstCard, y => y.MapFrom(z => z["FirstCard"]))
                .ForMember(x => x.HandStrength, y => y.MapFrom(z => z["HandStrength"]))
                .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
                .ForMember(x => x.SecondCard, y => y.MapFrom(z => z["SecondCard"]));

            this.CreateMap<List<ShowCardsBindingModel>, ShowCardsListBindingModel>()
                .ForMember(x => x.ShowCardsBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, UncalledBetsBindingModel>()
               .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
               .ForMember(x => x.Value, y => y.MapFrom(z => decimal.Parse(z["Value"])))
               .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]));

            this.CreateMap<List<UncalledBetsBindingModel>, UncalledBetsListBindingModel>()
                .ForMember(x => x.UncalledBetsBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, MuckHandBindingModel>()
               .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]));

            this.CreateMap<List<MuckHandBindingModel>, MuckHandListBindingModel>()
               .ForMember(x => x.MuckHandBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, CollectMoneyBindingModel>()
               .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
               .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
               .ForMember(x => x.Value, y => y.MapFrom(z => decimal.Parse(z["Value"])));

            this.CreateMap<List<CollectMoneyBindingModel>, CollectMoneyListBindingModel>()
               .ForMember(x => x.CollectMoneyBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, PotRakeSummaryBindingModel>()
               .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
               .ForMember(x => x.Pot, y => y.MapFrom(z => decimal.Parse(z["Pot"])))
               .ForMember(x => x.Rake, y => y.MapFrom(z => decimal.Parse(z["Rake"])));

            this.CreateMap<Dictionary<string, string>, BoardSummaryBindingModel>()
              .ForMember(x => x.FifthCard, y => y.MapFrom(z => z["FifthCard"] == "" ? null : z["FifthCard"]))
              .ForMember(x => x.FirstCard, y => y.MapFrom(z => z["FirstCard"] == "" ? null : z["FirstCard"]))
              .ForMember(x => x.FourthCard, y => y.MapFrom(z => z["FourthCard"] == "" ? null : z["FourthCard"]))
              .ForMember(x => x.SecondCard, y => y.MapFrom(z => z["SecondCard"] == "" ? null : z["SecondCard"]))
              .ForMember(x => x.ThirdCard, y => y.MapFrom(z => z["ThirdCard"] == "" ? null : z["ThirdCard"]));

            this.CreateMap<Dictionary<string, string>, FoldSummaryBindingModel>()
             .ForMember(x => x.DidNotBet, y => y.MapFrom(z => z["DidNotBet"] == "" ? true : false))
             .ForMember(x => x.IsBeforeRound, y => y.MapFrom(z => z["IsBeforeRound"] == "before" ? true : false))
             .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
             .ForMember(x => x.Position, y => y.MapFrom(z => z["Position"]))
             .ForMember(x => x.Round, y => y.MapFrom(z => z["Round"]))
             .ForMember(x => x.SeatNumber, y => y.MapFrom(z => int.Parse(z["SeatNumber"])));

            this.CreateMap<List<FoldSummaryBindingModel>, FoldSummaryListBindingModel>()
               .ForMember(x => x.FoldSummaryBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, MuckSummaryBindingModel>()
              .ForMember(x => x.FirstCard, y => y.MapFrom(z => z["FirstCard"]))
              .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
              .ForMember(x => x.Position, y => y.MapFrom(z => z["Position"]))
              .ForMember(x => x.SeatNumber, y => y.MapFrom(z => int.Parse(z["SeatNumber"])))
              .ForMember(x => x.SecondCard, y => y.MapFrom(z => z["SecondCard"]));

            this.CreateMap<List<MuckSummaryBindingModel>, MuckSummaryListBindingModel>()
               .ForMember(x => x.MuckSummaryBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, CollectSummaryBindingModel>()
              .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
              .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
              .ForMember(x => x.Position, y => y.MapFrom(z => z["Position"]))
              .ForMember(x => x.SeatNumber, y => y.MapFrom(z => int.Parse(z["SeatNumber"])))
              .ForMember(x => x.Value, y => y.MapFrom(z => decimal.Parse(z["Value"])));

            this.CreateMap<List<CollectSummaryBindingModel>, CollectSummaryListBindingModel>()
               .ForMember(x => x.CollectSummaryBindingModels, y => y.MapFrom(z => z));

            this.CreateMap<Dictionary<string, string>, ShowSummaryBindingModel>()
              .ForMember(x => x.CurrencySymbol, y => y.MapFrom(z => z["CurrencySymbol"] == "" ? null : z["CurrencySymbol"]))
              .ForMember(x => x.FirstCard, y => y.MapFrom(z => z["FirstCard"]))
              .ForMember(x => x.HandStrength, y => y.MapFrom(z => z["HandStrength"]))
              .ForMember(x => x.PlayerName, y => y.MapFrom(z => z["PlayerName"]))
              .ForMember(x => x.Position, y => y.MapFrom(z => z["Position"]))
              .ForMember(x => x.SeatNumber, y => y.MapFrom(z => int.Parse(z["SeatNumber"])))
              .ForMember(x => x.SecondCard, y => y.MapFrom(z => z["SecondCard"]))
              .ForMember(x => x.Value, y => y.MapFrom(z => decimal.TryParse(z["Value"], out temp) ? temp : (decimal?)null));

            this.CreateMap<List<ShowSummaryBindingModel>, ShowSummaryListBindingModel>()
               .ForMember(x => x.ShowSummaryBindingModels, y => y.MapFrom(z => z));



            this.CreateMap<BettingActionBindingModel, BettingActionDto>();
            this.CreateMap<BettingActionsByRoundBindingModel, BettingActionsByRoundDto>()
                .ForMember(x => x.Round, y => y.MapFrom(z => z.Round))
                .ForMember(x => x.BettingActionDtos, y => y.MapFrom(z => z.BettingActionBindingModels));
            this.CreateMap<BettingActionsByRoundListBindingModel, BettingActionsByRoundListDto>()
                .ForMember(x => x.BettingActionsByRoundDtos, y => y.MapFrom(z => z.BettingActionsByRoundBindingModels));
            this.CreateMap<BoardSummaryBindingModel, BoardSummaryDto>();
            this.CreateMap<CollectMoneyBindingModel, CollectMoneyDto>();
            this.CreateMap<CollectMoneyListBindingModel, CollectMoneyListDto>()
                .ForMember(x => x.CollectMoneyDtos, y => y.MapFrom(z => z.CollectMoneyBindingModels));
            this.CreateMap<CollectSummaryBindingModel, CollectSummaryDto>();
            this.CreateMap<CollectSummaryListBindingModel, CollectSummaryListDto>()
                .ForMember(x => x.CollectSummaryDtos, y => y.MapFrom(z => z.CollectSummaryBindingModels));
            this.CreateMap<DealtCardsBindingModel, DealtCardsDto>();
            this.CreateMap<FoldSummaryBindingModel, FoldSummaryDto>();
            this.CreateMap<FoldSummaryListBindingModel, FoldSummaryListDto>()
                .ForMember(x => x.FoldSummaryDtos, y => y.MapFrom(z => z.FoldSummaryBindingModels));
            this.CreateMap<HandInfoBindingModel, HandInfoDto>();
            this.CreateMap<MuckHandBindingModel, MuckHandDto>();
            this.CreateMap<MuckHandListBindingModel, MuckHandListDto>()
                .ForMember(x => x.MuckHandDtos, y => y.MapFrom(z => z.MuckHandBindingModels));
            this.CreateMap<MuckSummaryBindingModel, MuckSummaryDto>();
            this.CreateMap<MuckSummaryListBindingModel, MuckSummaryListDto>()
                .ForMember(x => x.MuckSummaryDtos, y => y.MapFrom(z => z.MuckSummaryBindingModels));
            this.CreateMap<PotRakeSummaryBindingModel, PotRakeSummaryDto>();
            this.CreateMap<RoundBindingModel, RoundDto>();
            this.CreateMap<RoundListBindingModel, RoundListDto>()
                .ForMember(x => x.RoundDtos, y => y.MapFrom(z => z.RoundBindingModels));
            this.CreateMap<SeatInfoBindingModel, SeatInfoDto>();
            this.CreateMap<SeatInfoListBindingModel, SeatInfoListDto>()
                .ForMember(x => x.SeatInfoDtos, y => y.MapFrom(z => z.SeatInfoBindingModels));
            this.CreateMap<ShowCardsBindingModel, ShowCardsDto>();
            this.CreateMap<ShowCardsListBindingModel, ShowCardsListDto>()
                .ForMember(x => x.ShowCardsDtos, y => y.MapFrom(z => z.ShowCardsBindingModels));
            this.CreateMap<ShowSummaryBindingModel, ShowSummaryDto>();
            this.CreateMap<ShowSummaryListBindingModel, ShowSummaryListDto>()
                .ForMember(x => x.ShowSummaryDtos, y => y.MapFrom(z => z.ShowSummaryBindingModels));
            this.CreateMap<TableBindingModel, TableDto>();
            this.CreateMap<UncalledBetsBindingModel, UncalledBetsDto>();
            this.CreateMap<UncalledBetsListBindingModel, UncalledBetsListDto>()
                .ForMember(x => x.UncalledBetsDtos, y => y.MapFrom(z => z.UncalledBetsBindingModels));

            this.CreateMap<HandBindingModel, HandDto>()
                .ForMember(x => x.BettingActionsByRoundListDto, y => y.MapFrom(z => z.BettingActionsByRoundListBindingModel))
                .ForMember(x => x.BoardSummaryDto, y => y.MapFrom(z => z.BoardSummaryBindingModel))
                .ForMember(x => x.CollectMoneyListDto, y => y.MapFrom(z => z.CollectMoneyListBindingModel))
                .ForMember(x => x.CollectSummaryListDto, y => y.MapFrom(z => z.CollectSummaryListBindingModel))
                .ForMember(x => x.DealtCardsDto, y => y.MapFrom(z => z.DealtCardsBindingModel))
                .ForMember(x => x.FoldSummaryListDto, y => y.MapFrom(z => z.FoldSummaryListBindingModel))
                .ForMember(x => x.HandInfoDto, y => y.MapFrom(z => z.HandInfoBindingModel))
                .ForMember(x => x.MuckHandListDto, y => y.MapFrom(z => z.MuckHandListBindingModel))
                .ForMember(x => x.MuckSummaryListDto, y => y.MapFrom(z => z.MuckSummaryListBindingModel))
                .ForMember(x => x.PotRakeSummaryDto, y => y.MapFrom(z => z.PotRakeSummaryBindingModel))
                .ForMember(x => x.RoundListDto, y => y.MapFrom(z => z.RoundListBindingModel))
                .ForMember(x => x.SeatInfoListDto, y => y.MapFrom(z => z.SeatInfoListBindingModel))
                .ForMember(x => x.ShowCardsListDto, y => y.MapFrom(z => z.ShowCardsListBindingModel))
                .ForMember(x => x.ShowSummaryListDto, y => y.MapFrom(z => z.ShowSummaryListBindingModel))
                .ForMember(x => x.TableDto, y => y.MapFrom(z => z.TableBindingModel))
                .ForMember(x => x.UncalledBetsListDto, y => y.MapFrom(z => z.UncalledBetsListBindingModel));

            //this.CreateMap<BoardSummaryDto, Board>()
            //    .ForMember(x => x.Flop, y => y.MapFrom(z => $"{z.FirstCard} {z.SecondCard} {z.ThirdCard}"))
            //    .ForMember(x => x.River, y => y.MapFrom(z => z.FifthCard))
            //    .ForMember(x => x.Turn, y => y.MapFrom(z => z.FourthCard));
            //this.CreateMap<HandInfoDto, Client>()
            //    .ForMember(x => x.Name, y => y.MapFrom(z => z.ClientName));
            //this.CreateMap<HandInfoDto, Hand>()
            //    //.ForPath(x => x.Client.Name, y => y.MapFrom(z => z.ClientName))
            //    .ForMember(x => x.LocalTime, y => y.MapFrom(z => z.LocalTime))
            //    .ForMember(x => x.LocalTimeZone, y => y.MapFrom(z => z.LocalTimeZone))
            //    .ForMember(x => x.Number, y => y.MapFrom(z => z.HandNumber))
            //    //.ForPath(x => x.Stake.BigBlind, y => y.MapFrom(z => z.BigBlind))
            //    //.ForPath(x => x.Stake.SmallBlind, y => y.MapFrom(z => z.SmallBlind))
            //    .ForMember(x => x.Time, y => y.MapFrom(z => z.Time))
            //    .ForMember(x => x.TimeZone, y => y.MapFrom(z => z.TimeZone));
            //    //.ForPath(x => x.Variant.Limit, y => y.MapFrom(z => z.Limit))
            //    //.ForPath(x => x.Variant.Name, y => y.MapFrom(z => z.VariantName));
        }
    }
}
