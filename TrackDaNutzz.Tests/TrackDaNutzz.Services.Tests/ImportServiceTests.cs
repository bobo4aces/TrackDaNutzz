using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.BettingActions;
using TrackDaNutzz.Services.Boards;
using TrackDaNutzz.Services.Clients;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Import;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.Services.Variant;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class ImportServiceTests
    {
        //void Add(ImportHandDto handDto);
        [Fact]
        public void TestAdd_WithOneHand_ShouldReturnCorrectResult()
        {
            //DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
            //    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            //    .Options;
            //TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
            //StatisticsService statisticsService = new StatisticsService(context);
            //UsersService usersService = new UsersService(context, null);
            //StakesService stakesService = new StakesService(context);
            //VariantsService variantsService = new VariantsService(context);
            //ClientsService clientsService = new ClientsService(context);
            //TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            //HandPlayersService handPlayersService = new HandPlayersService(context);
            //HandsService handsService = new HandsService(context, handPlayersService);
            //BoardsService boardsService = new BoardsService(context);
            //BettingActionsService bettingActionsService = new BettingActionsService(context, handPlayersService);
            //PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService,handsService);
            //ImportService importService = new ImportService(context, statisticsService, usersService, tablesService, playersService,variantsService,stakesService,handsService,boardsService,clientsService, bettingActionsService);
            //ImportHandDto importHand = this.GetTestImportHand();
            //importService.Add(importHand);
            //int clientsCount = context.Clients.Count();
            //int expected = 1;
            //int actual = clientsCount;
            //
            //Assert.Equal(expected, actual);
        }

        private ImportHandDto GetTestImportHand()
        {
            ImportHandDto importHandDto = new ImportHandDto()
            {
                BettingActionsByRoundListDto = new BettingActionsByRoundListDto()
                {
                    BettingActionsByRoundDtos = new List<BettingActionsByRoundDto>()
                    {
                        new BettingActionsByRoundDto()
                        {
                            BettingActionDtos = new List<BettingActionDto>()
                            {
                                new BettingActionDto()
                                {
                                    Action = "POST SMALL BLIND",
                                    CurrencySymbol = "$",
                                    IsAllIn = false,
                                    PlayerName = "Sigtip",
                                    RaiseTo = null,
                                    Value = 0.01m,
                                }
                            },
                            Round = "PREFLOP"
                        }
                    },

                },
                ShowCardsListDto = new ShowCardsListDto()
                {
                    ShowCardsDtos = new List<ShowCardsDto>()
                    {
                        new ShowCardsDto()
                        {
                            FirstCard = "2s",
                            HandStrength = "a straight, Five to Nine",
                            PlayerName = "Sigtip",
                            SecondCard = "2d",
                        },
                    }
                },
                MuckHandListDto = new MuckHandListDto()
                {
                    MuckHandDtos = new List<MuckHandDto>()
                    {
                        new MuckHandDto()
                        {
                            PlayerName = "Sigtip",
                        }
                    }
                },
                SeatInfoListDto = new SeatInfoListDto()
                {
                    SeatInfoDtos = new List<SeatInfoDto>()
                    {
                        new SeatInfoDto()
                        {
                            CurrencySymbol = "$",
                            Money = 2m,
                            PlayerName = "Sigtip",
                            SeatNumber = 4,
                        }
                    }
                },
                CollectMoneyListDto = new CollectMoneyListDto()
                {
                    CollectMoneyDtos = new List<CollectMoneyDto>()
                    {
                        new CollectMoneyDto()
                        {
                            CurrencySymbol = "$",
                            PlayerName = "Sigtip",
                            Value = 2m,
                        }
                    }
                },
                HandInfoDto = new HandInfoDto()
                {
                    BigBlind = 0.02m,
                    ClientName = "PokerStars",
                    Currency = "USD",
                    CurrencySymbol = '$',
                    HandNumber = 202717426423,
                    Limit = "No Limit",
                    LocalTime = DateTime.Now,
                    LocalTimeZone = "ET",
                    SmallBlind = 0.01m,
                    Time = DateTime.Now,
                    TimeZone = "EET",
                    VariantName = "Hold'em",
                },
                ImportTableDto = new ImportTableDto()
                {
                    ButtonSeat = 4,
                    PlayMoney = true,
                    TableName = "Hatshepsut II",
                    TableSize = "6-max",
                },
                PotRakeSummaryDto = new PotRakeSummaryDto()
                {
                    CurrencySymbol = "$",
                    Pot = 0.10m,
                    Rake = 0.01m
                },
            };

            return importHandDto;
        }
    }
}
