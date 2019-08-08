using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
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
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class HandsServiceTests
    {
        //long AddHand(ImportHandDto handDto, long? boardId, int tableId);
        //IQueryable<long> GetHandIdsByTableId(params int[] tableIds);
        //IQueryable<int> GetTableIdsByHandId(params long[] handIds);
        //IQueryable<HandDto> GetAllHandsByPlayerId(int playerId);

        [Fact]
        public void TestAddHand_WithOneHand_ShouldReturnCorrectHandId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            HandsService handsService = new HandsService(context, handPlayersService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = handsService.AddHand(importHandDto, null, 1);

            long expected = 2;
            long actual = handId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetHandIdsByTableId_WithOneTableId_ShouldReturnCorrectHandId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            HandsService handsService = new HandsService(context, handPlayersService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handIdAdded = handsService.AddHand(importHandDto, null, 1);
            int tableId = 1;
            long handId = handsService.GetHandIdsByTableId(tableId).FirstOrDefault();
            long expected = 4;
            long actual = handId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetTableIdsByHandId_WithOneHandId_ShouldReturnCorrectTableId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            HandsService handsService = new HandsService(context, handPlayersService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handIdAdded = handsService.AddHand(importHandDto, null, 1);
            int tableId = handsService.GetTableIdsByHandId(handIdAdded).FirstOrDefault();
            long expected = 1;
            long actual = tableId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetAllHandsByPlayerId_WithOnePlayerId_ShouldReturnCorrectHand()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            Player player = this.GetTestPlayer();
            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = handsService.AddHand(importHandDto, null, 1);
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            handPlayersService.AddHandPlayer(importHandDto, handId, statisticsIdsByPlayerName, seatInfoDto, player);
            HandDto handDto = handsService.GetAllHandsByPlayerId(player.Id).FirstOrDefault();
            long expected = 3;
            long actual = handDto.Id;

            Assert.Equal(expected, actual);
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

        private Player GetTestPlayer()
        {
            Player player = new Player()
            {
                Id = 1,
                IsActive = false,
                Name = "Sigtip",
                TrackDaNutzzUserId = Guid.NewGuid().ToString(),
            };
            return player;
        }

        private Dictionary<string, long> GetTestStatisticsIdsByPlayerName()
        {
            Dictionary<string, long> statisticsIdsByPlayerName = new Dictionary<string, long>();
            statisticsIdsByPlayerName.Add("Sigtip", 1);
            return statisticsIdsByPlayerName;
        }
    }

}
