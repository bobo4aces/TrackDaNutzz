using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.HandPlayers;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class HandPlayersServiceTests
    {

        //bool AddHandPlayer(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, SeatInfoDto seatInfoDto, Player player);
        //bool AddBettingActionIdSplitByPipe(long bettingActionId, long handId, int playerId);
        //IQueryable<long> GetAllHandIdsByPlayer(int playerId);
        //IQueryable<long> GetStatisticIdsByPlayerIdAndHandId(int playerId, params long[] handIds);
        //IQueryable<int> GetAllPlayerIdsByHandId(params long[] handIds);
        //decimal GetWinnings(int playerId, WinningsType winningsType, TotalAverage totalOrAverage, TimePeriod timePeriod, int timePeriodCount);
        [Fact]
        public void TestAddHandPlayer_WithOnePlayer_ShouldReturnTrue()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAdded = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);

            bool expected = true;
            bool actual = isAdded;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddHandPlayer_WithTwoSamePlayers_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAdded = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            bool isAddedSecondPlayer = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);

            bool expected = false;
            bool actual = isAddedSecondPlayer;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddBettingActionIdSplitByPipe_WithOneBettingActionId_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAddedHandPlayer = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            long bettingActionId = 1;
            long handId = 1;
            int playerId = 1;
            bool isAddedBettingAction = handPlayersService.AddBettingActionIdSplitByPipe(bettingActionId, handId, playerId);

            bool expected = true;
            bool actual = isAddedBettingAction;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddBettingActionIdSplitByPipe_WithNonExistingPlayerId_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAddedHandPlayer = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            long bettingActionId = 1;
            long handId = 1;
            int playerId = 2;
            bool isAddedFirstBettingAction = handPlayersService.AddBettingActionIdSplitByPipe(bettingActionId, handId, playerId);
            bool isAddedSecondBettingAction = handPlayersService.AddBettingActionIdSplitByPipe(bettingActionId, handId, playerId);

            bool expected = false;
            bool actual = isAddedSecondBettingAction;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddBettingActionIdSplitByPipe_WithNonExistingHandId_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAddedHandPlayer = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            long bettingActionId = 1;
            long handId = 2;
            int playerId = 1;
            bool isAddedFirstBettingAction = handPlayersService.AddBettingActionIdSplitByPipe(bettingActionId, handId, playerId);
            bool isAddedSecondBettingAction = handPlayersService.AddBettingActionIdSplitByPipe(bettingActionId, handId, playerId);

            bool expected = false;
            bool actual = isAddedSecondBettingAction;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAllHandIdsByPlayer_WithOnePlayerId_ShouldReturnCorrectHandId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAddedHandPlayer = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            int playerId = 1;
            List<long> allHandIdsByPlayer = handPlayersService.GetAllHandIdsByPlayer(playerId).ToList();

            long expected = 1;
            long actual = allHandIdsByPlayer.FirstOrDefault();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAllHandIdsByPlayer_WithNonExistingPlayerId_ShouldReturnEmptyList()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAddedHandPlayer = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            int playerId = 2;
            List<long> allHandIdsByPlayer = handPlayersService.GetAllHandIdsByPlayer(playerId).ToList();

            long expected = 0;
            long actual = allHandIdsByPlayer.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetStatisticIdsByPlayerIdAndHandId_WithOnePlayerIdAndHandId_ShouldReturnCorrectStatisticsId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAdded = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            int playerId = 1;
            long handId = 1;
            List<long> statisticIdsByPlayerIdAndHandId = handPlayersService.GetStatisticIdsByPlayerIdAndHandId(playerId, handId).ToList();

            long expected = 1;
            long actual = statisticIdsByPlayerIdAndHandId.FirstOrDefault();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetAllPlayerIdsByHandId_WithOneHandId_ShouldReturnCorrectPlayerId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);

            ImportHandDto importHandDto = this.GetTestImportHand();
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Player player = this.GetTestPlayer();
            bool isAdded = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
            int playerId = 1;
            long handId = 1;
            List<int> allPlayerIdsByHandId = handPlayersService.GetAllPlayerIdsByHandId(handId).ToList();

            long expected = 1;
            long actual = allPlayerIdsByHandId.FirstOrDefault();

            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void TestGetWinnings_WithOneHandId_ShouldReturnCorrectPlayerId()
        //{
        //    DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
        //        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        //        .Options;
        //    TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
        //
        //    HandPlayersService handPlayersService = new HandPlayersService(context);
        //    StatisticsService statisticsService = new StatisticsService(context);
        //    ImportHandDto importHandDto = this.GetTestImportHand();
        //    Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
        //    SeatInfoDto seatInfoDto = importHandDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
        //    Player player = this.GetTestPlayer();
        //    bool isAdded = handPlayersService.AddHandPlayer(importHandDto, 1, statisticsIdsByPlayerName, seatInfoDto, player);
        //    int playerId = 1;
        //    long handId = 1;
        //    //Dictionary<string, long> addedStatistics = statisticsService.AddStatistics(importHandDto);
        //    HandPlayer handPlayer = this.GetTestHandPlayer();
        //    decimal winnings = handPlayersService.GetWinnings(playerId, WinningsType.Money, TotalAverage.Total, TimePeriod.Month, -1);
        //
        //    decimal expected = -0.01m;
        //    decimal actual = winnings;
        //
        //    Assert.Equal(expected, actual);
        //}

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

            };

            return importHandDto;
        }

        private Dictionary<string, long> GetTestStatisticsIdsByPlayerName()
        {
            Dictionary<string, long> statisticsIdsByPlayerName = new Dictionary<string, long>();
            statisticsIdsByPlayerName.Add("Sigtip", 1);
            return statisticsIdsByPlayerName;
        }

        private Player GetTestPlayer()
        {
            Player player = new Player()
            {
                Id = 1,
                IsActive = true,
                Name = "Sigtip",
                TrackDaNutzzUserId = "2ef1e335-5f2d-453b-8d98-3f40c6eb38e2",
            };
            return player;
        }

        private HandPlayer GetTestHandPlayer()
        {
            HandPlayer handPlayer = new HandPlayer()
            {
                BettingActionIds = new List<long>() { 1, 2 },
                FinalStack = 2m,
                HandId = 1,
                Hand = new Hand()
                {
                    BoardId = null,
                    Board = null,
                    Button = 2,
                    HandPlayers = null,
                    Id = 1,
                    LocalTime = DateTime.Now,
                    LocalTimeZone = "ET",
                    Number = 202717426423,
                    Pot = 2,
                    Rake = 0.2m,
                    Time = DateTime.Now,
                    TimeZone = "EET",
                },
                HasShowdown = false,
                HoleCards = "2s 2d",
                IsAllIn = false,
                IsMuckCards = false,
                PlayerId = 1,
                SeatNumber = 1,
                StackDifference = 1m,
                StartingStack = 1m,
                StatisticId = 1,
                Statistic = new Statistic()
                {
                    BigBlindsWon = 100,
                    ContinuationBet = false,
                    FourBet = false,
                    Id = 1,
                    MoneyWon = 1,
                    PreFlopRaise = false,
                    ThreeBet = false,
                    TotalBets = 1,
                    TotalCalls = 1,
                    TotalRaises = 1,
                    VoluntaryPutMoneyInPot = true,
                },
                BettingActionIdsJoinByPipe = "1|2",
            };
            return handPlayer;
        }
    }
}
