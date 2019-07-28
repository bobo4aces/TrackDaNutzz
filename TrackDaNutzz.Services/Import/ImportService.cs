using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Common;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Users;

namespace TrackDaNutzz.Services.Import
{
    public class ImportService : IImportService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IMapper mapper;
        private readonly IStatisticsService statisticsService;
        private readonly IUsersService usersService;

        public ImportService(TrackDaNutzzDbContext context, IMapper mapper, IStatisticsService statisticsService, IUsersService usersService)
        {
            this.context = context;
            this.mapper = mapper;
            this.statisticsService = statisticsService;
            this.usersService = usersService;
        }

        public bool Add(HandDto handDto)
        {
            long? boardId = null;
            if (handDto.BoardSummaryDto.FirstCard != null)
            {
                boardId = this.AddBoard(handDto.BoardSummaryDto);
            }
            int clientId = this.AddClient(handDto.HandInfoDto);
            int stakeId = this.AddStake(handDto.HandInfoDto);
            int variantId = this.AddVariant(handDto.HandInfoDto);
            int tableId = this.AddTable(handDto.TableDto, clientId, stakeId,variantId);
            long handId = this.AddHand(handDto, boardId, tableId);
            Dictionary<string, long> statisticsIdsByPlayerName = this.statisticsService.AddStatistics(handDto);
            string currentLoggedInUsername = this.usersService.GetCurrentlyLoggedUsername();
            string currentLoggedInUserId = this.usersService.GetCurrentlyLoggedUserId(currentLoggedInUsername);
            Dictionary<string, int> playerIdsByName = this.AddPlayers(handDto, handId, statisticsIdsByPlayerName, currentLoggedInUserId);
            List<long> bettingActionsIds = this.AddBettingActions(handDto, handId, playerIdsByName);
            this.context.SaveChanges();
            //TODO: Add Mapping Table HandPlayerBettingAction (for mapping bettingAction order)!!!!!!!!!! - I think no
            return true;
        }

        private int AddTable(TableDto tableDto, int clientId, int stakeId, int variantId)
        {
            int tableSize = 0;
            if (tableDto.TableSize.EndsWith(GlobalConstants.TableSizeEnding))
            {
                tableSize = int.Parse(tableDto.TableSize.Replace(GlobalConstants.TableSizeEnding, string.Empty));
            }
            else if (tableDto.TableSize == GlobalConstants.HeadsUp)
            {
                tableSize = 2;
            }

            Table table = this.context.Tables
                .SingleOrDefault(t => t.Name == tableDto.TableName && t.Size == tableSize && 
                                      t.ClientId == clientId && t.StakeId == stakeId && 
                                      t.VariantId == variantId);
            if (table != null)
            {
                return table.Id;
            }
            table = new Table()
            {
                Name = tableDto.TableName,
                Size = tableSize,
                ClientId = clientId,
                StakeId = stakeId,
                VariantId = variantId,
            };
            this.context.Tables.Add(table);
            this.context.SaveChanges();
            return table.Id;
        }

        private Dictionary<string, int> AddPlayers(HandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId)
        {
            Dictionary<string, int> playersIdsByName = new Dictionary<string, int>();
            foreach (var seatInfoDto in handDto.SeatInfoListDto.SeatInfoDtos)
            {
                Player player = this.context.Players
                    .SingleOrDefault(p => p.Name == seatInfoDto.PlayerName && p.TrackDaNutzzUserId == userId);
                if (player == null)
                {
                    player = new Player()
                    {
                        Name = seatInfoDto.PlayerName,
                        TrackDaNutzzUserId = userId
                    };
                    this.context.Players.Add(player);
                    this.context.SaveChanges();
                }
                HandPlayer handPlayer = this.context.HandPlayers.SingleOrDefault(x => x.HandId == handId && x.PlayerId == player.Id);
                if (handPlayer == null)
                {
                    decimal finalStack = this.CalculateFinalStack(handDto, seatInfoDto);
                    handPlayer = new HandPlayer()
                    {
                        HandId = handId,
                        Player = player,
                        HasShowdown = handDto.ShowCardsListDto.ShowCardsDtos.Any(x => x.PlayerName == seatInfoDto.PlayerName),
                        HoleCards = GetHoleCards(handDto, seatInfoDto),
                        FinalStack = finalStack,
                        IsAllIn = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                        .Any(x => x.BettingActionDtos.Where(y => y.PlayerName == seatInfoDto.PlayerName).Any(z => z.IsAllIn.Value == true)),
                        //IsInPosition = ,
                        IsMuckCards = handDto.MuckHandListDto.MuckHandDtos.Any(x => x.PlayerName == seatInfoDto.PlayerName),
                        SeatNumber = seatInfoDto.SeatNumber,
                        StartingStack = seatInfoDto.Money,
                        StackDifference = finalStack - seatInfoDto.Money,
                        StatisticId = statisticsIdsByPlayerName[seatInfoDto.PlayerName]
                    };
                    this.context.HandPlayers.Add(handPlayer);
                    this.context.SaveChanges();
                }
                playersIdsByName.Add(player.Name, player.Id);
            }
            return playersIdsByName;
        }

        private string GetHoleCards(HandDto handDto, SeatInfoDto seatInfoDto)
        {
            var cards = handDto.ShowCardsListDto.ShowCardsDtos
                                                .Where(x => x.PlayerName == seatInfoDto.PlayerName)
                                                .Select(x => new { x.FirstCard, x.SecondCard })
                                                .ToList();
            string holeCards = null;
            if (cards.Count > 0)
            {
                holeCards = $"{cards[0].FirstCard} {cards[0].SecondCard}";
            }
            return holeCards;
        }

        private decimal CalculateFinalStack(HandDto handDto, SeatInfoDto seatInfoDto)
        {
            decimal betMoney = handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos
                        .SelectMany(x => x.BettingActionDtos
                                    .Where(y => y.PlayerName == seatInfoDto.PlayerName && y.Value.HasValue)
                                    .Select(z => z.RaiseTo.HasValue ? z.RaiseTo.Value : z.Value.Value)
                        .ToList())
                        .ToList()
                        .Sum();
            decimal collectedMoney = handDto.CollectMoneyListDto.CollectMoneyDtos
                        .Where(x => x.PlayerName == seatInfoDto.PlayerName)
                        .Sum(x => x.Value);
            return seatInfoDto.Money - betMoney + collectedMoney;
        }

        private int AddVariant(HandInfoDto handInfoDto)
        {
            Variant variant = this.context.Variants.SingleOrDefault(v => v.Name == handInfoDto.VariantName && v.Limit == handInfoDto.Limit);
            if (variant != null)
            {
                return variant.Id;
            }
            variant = new Variant()
            {
                Limit = handInfoDto.Limit,
                Name = handInfoDto.VariantName
            };
            this.context.Variants.Add(variant);
            this.context.SaveChanges();
            return variant.Id;
        }

        private int AddStake(HandInfoDto handInfoDto)
        {
            Stake stake = this.context.Stakes
                .SingleOrDefault(s => s.BigBlind == handInfoDto.BigBlind && s.SmallBlind == handInfoDto.SmallBlind &&
                                    s.Currency == handInfoDto.Currency && s.CurrencySymbol == handInfoDto.CurrencySymbol);
            if (stake != null)
            {
                return stake.Id;
            }
            stake = new Stake()
            {
                Currency = handInfoDto.Currency,
                CurrencySymbol = handInfoDto.CurrencySymbol,
                BigBlind = handInfoDto.BigBlind,
                SmallBlind = handInfoDto.SmallBlind
            };
            this.context.Stakes.Add(stake);
            this.context.SaveChanges();
            return stake.Id;
        }

        private long AddHand(HandDto handDto, long? boardId, int tableId)
        {
            Hand hand = this.context.Hands.SingleOrDefault(h => h.Number == handDto.HandInfoDto.HandNumber);
            if (hand != null)
            {
                return hand.Id;
            }
            Client client = this.context.Clients.SingleOrDefault(c => c.Name == handDto.HandInfoDto.ClientName);
            if (client == null)
            {
                throw new ArgumentNullException("Cannot add Hand without a Client");
            }
            Stake stake = this.context.Stakes.SingleOrDefault(s => s.BigBlind == handDto.HandInfoDto.BigBlind && s.SmallBlind == handDto.HandInfoDto.SmallBlind);
            if (stake == null)
            {
                throw new ArgumentNullException("Cannot add Hand without a Stake");
            }
            Variant variant = this.context.Variants.SingleOrDefault(v => v.Name == handDto.HandInfoDto.VariantName && v.Limit == handDto.HandInfoDto.Limit);
            if (variant == null)
            {
                throw new ArgumentNullException("Cannot add Hand without a Variant");
            }
            Table table = this.context.Tables.SingleOrDefault(t => t.Id == tableId);
            if (table == null)
            {
                throw new ArgumentNullException("Cannot add Hand without a Table");
            }
            hand = new Hand()
            {
                Client = client,
                ClientId = client.Id,
                LocalTime = handDto.HandInfoDto.LocalTime,
                LocalTimeZone = handDto.HandInfoDto.LocalTimeZone,
                Number = handDto.HandInfoDto.HandNumber,
                Stake = stake,
                StakeId = stake.Id,
                Time = handDto.HandInfoDto.Time,
                TimeZone = handDto.HandInfoDto.TimeZone,
                Variant = variant,
                VariantId = variant.Id,
                BoardId = boardId,
                Button = handDto.TableDto.ButtonSeat,
                Pot = handDto.PotRakeSummaryDto.Pot,
                Rake = handDto.PotRakeSummaryDto.Rake,
                Table = table,
                TableId = tableId
            };
            this.context.Hands.Add(hand);
            this.context.SaveChanges();
            return hand.Id;
        }

        //TODO: don't get handplayer from db
        private List<long> AddBettingActions(HandDto handDto, long handId, Dictionary<string, int> playerIdsByName)
        {
            List<long> bettingActionsIds = new List<long>();
            foreach (var bettingActionsByRoundDto in handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos)
            {
                foreach (var bettingActionDto in bettingActionsByRoundDto.BettingActionDtos)
                {
                    BettingAction bettingAction = new BettingAction()
                    {
                        Round = bettingActionsByRoundDto.Round,
                        Name = bettingActionDto.Action,
                        Value = bettingActionDto.RaiseTo == null ? bettingActionDto.Value : bettingActionDto.RaiseTo - bettingActionDto.Value,
                        Type = bettingActionDto.Action.Contains(BettingActionNamesConstants.Bet) || bettingActionDto.Action.Contains(BettingActionNamesConstants.Raise)
                    };
                    BettingAction bettingActionFromDb = this.context.BettingActions
                        .SingleOrDefault(x => x.Name == bettingAction.Name && 
                                            x.Round == bettingAction.Round && 
                                            x.Type == bettingAction.Type && 
                                            x.Value == bettingAction.Value);
                    long bettingActionId = 0;
                    string playerName = bettingActionDto.PlayerName;
                    HandPlayer handPlayer = this.context.HandPlayers
                        .FirstOrDefault(x => x.HandId == handId && x.PlayerId == playerIdsByName[playerName]);
                    if (bettingActionFromDb == null)
                    {
                        this.context.BettingActions.Add(bettingAction);
                        this.context.SaveChanges();
                        bettingActionId = bettingAction.Id;
                    }
                    else
                    {
                        bettingActionId = bettingActionFromDb.Id;
                    }
                    handPlayer.BettingActionIds.Add(bettingActionId);
                    bettingActionsIds.Add(bettingActionId);
                    this.context.SaveChanges();
                }
            }
            return bettingActionsIds;
        }

        private long AddBoard(BoardSummaryDto boardSummaryDto)
        {
            Board board = new Board()
            {
                Flop = boardSummaryDto.FirstCard == null ? null : $"{boardSummaryDto.FirstCard} {boardSummaryDto.SecondCard} {boardSummaryDto.ThirdCard}",
                Turn = boardSummaryDto.FourthCard,
                River = boardSummaryDto.FifthCard
            };
            Board boardFromDb = this.context.Boards
                .SingleOrDefault(b => b.Flop == board.Flop && b.Turn == board.Turn && b.River == board.River);
            if (boardFromDb != null)
            {
                return boardFromDb.Id;
            }
            this.context.Boards.Add(board);
            this.context.SaveChanges();
            return board.Id;
        }

        private int AddClient(HandInfoDto handInfoDto)
        {
            Client client = this.context.Clients.SingleOrDefault(c => c.Name == handInfoDto.ClientName);
            if (client != null)
            {
                return client.Id;
            }
            client = new Client()
            {
                Name = handInfoDto.ClientName
            };
            this.context.Clients.Add(client);
            this.context.SaveChanges();
            return client.Id;
        }

        private List<BettingAction> GetBettingActions(HandDto handDto)
        {
            List<BettingAction> bettingActions = new List<BettingAction>();
            foreach (var bettingActionsByRoundDto in handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos)
            {
                foreach (var bettingActionDto in bettingActionsByRoundDto.BettingActionDtos)
                {
                    BettingAction bettingAction = new BettingAction()
                    {
                        Round = bettingActionsByRoundDto.Round,
                        Name = bettingActionDto.Action,
                        Value = bettingActionDto.RaiseTo == null ? bettingActionDto.Value : bettingActionDto.RaiseTo - bettingActionDto.Value,
                        Type = bettingActionDto.Action.Contains(BettingActionNamesConstants.Bet) || bettingActionDto.Action.Contains(BettingActionNamesConstants.Raise)
                    };
                }

            }
            return bettingActions;
        }
    }
}
