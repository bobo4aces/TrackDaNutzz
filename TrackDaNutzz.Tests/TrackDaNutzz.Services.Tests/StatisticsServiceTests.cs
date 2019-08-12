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
using TrackDaNutzz.Services.Dtos.Statistics;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.Statistics;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class StatisticsServiceTests
    {
        //Dictionary<string, long> AddStatistics(ImportHandDto handDto);
        //Statistic CreateStatistic(ImportHandDto handDto, string playerName, List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions, List<BettingActionDto> playerAllBettingActions, SeatInfoDto seatInfoDto);
        //bool GetContinuationBet(List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions);
        //decimal GetBigBlindsWon(decimal moneyWon, decimal bigBlind);
        //decimal GetMoneyWon(ImportHandDto handDto, SeatInfoDto seatInfoDto);
        //decimal GetAggressionFactor(int totalRaises, int totalBets, int totalCalls);
        //bool GetFourBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        //bool GetThreeBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        //bool GetPreFlopRaise(List<BettingActionDto> playerPreflopBettingActions);
        //bool GetVoluntaryPutMoneyInPot(List<BettingActionDto> playerPreflopBettingActions);
        //IQueryable<StatisticsDto> GetStatisticsById(params long[] statisticsIds);

        [Fact]
        public void TestAddStatistics_WithOneImportHandDto_ShouldReturnCorrectCount()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            ImportHandDto handDto = this.GetTestImportHand();

            Dictionary<string, long> statisticsIdsByPlayerName = statisticsService.AddStatistics(handDto);

            int expected = 1;
            int actual = statisticsIdsByPlayerName.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateStatistic_WithOnePlayer_ShouldReturnCorrectStatistics()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            ImportHandDto handDto = this.GetTestImportHand();

            Dictionary<string, long> statisticsIdsByPlayerName = statisticsService.AddStatistics(handDto);
            string playerName = "Sigtip";
            List<BettingActionDto> playerPreflopBettingActions = this.GetBettingActionDtos();
            List<BettingActionDto> playerFlopBettingActions = new List<BettingActionDto>();
            List<BettingActionDto> playerAllBettingActions = new List<BettingActionDto>();
            SeatInfoDto seatInfoDto = this.GetTestImportHand().SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Statistic statistic = statisticsService.CreateStatistic(handDto, playerName, playerPreflopBettingActions, playerFlopBettingActions, playerAllBettingActions, seatInfoDto);

            Assert.NotNull(statistic);
        }


        //bool GetContinuationBet(List<BettingActionDto> playerPreflopBettingActions, List<BettingActionDto> playerFlopBettingActions);

        [Fact]
        public void TestGetContinuationBet_WithNoContinuationBet_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            ImportHandDto handDto = this.GetTestImportHand();

            Dictionary<string, long> statisticsIdsByPlayerName = statisticsService.AddStatistics(handDto);
            string playerName = "Sigtip";
            List<BettingActionDto> playerPreflopBettingActions = this.GetBettingActionDtos();
            List<BettingActionDto> playerFlopBettingActions = new List<BettingActionDto>();
            List<BettingActionDto> playerAllBettingActions = new List<BettingActionDto>();
            SeatInfoDto seatInfoDto = this.GetTestImportHand().SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            Statistic statistic = statisticsService.CreateStatistic(handDto, playerName, playerPreflopBettingActions, playerFlopBettingActions, playerAllBettingActions, seatInfoDto);

            bool isContinuationBet = statisticsService.GetContinuationBet(playerPreflopBettingActions, playerFlopBettingActions);

            bool expected = false;
            bool actual = isContinuationBet;

            Assert.Equal(expected, actual);
        }

        //decimal GetBigBlindsWon(decimal moneyWon, decimal bigBlind);

        [Fact]
        public void TestGetBigBlindsWon_WithTestData_ShouldReturnCorrectBigBlindsWon()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            decimal moneyWon = 2m;
            decimal bigBlind = 0.02m;
            decimal bigBlindsWon = statisticsService.GetBigBlindsWon(moneyWon, bigBlind);

            decimal expected = 100m;
            decimal actual = bigBlindsWon;

            Assert.Equal(expected, actual);
        }

        //decimal GetMoneyWon(ImportHandDto handDto, SeatInfoDto seatInfoDto);

        [Fact]
        public void TestGetMoneyWon_WithOneImportHandDto_ShouldReturnCorrectMoneyWon()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            ImportHandDto handDto = this.GetTestImportHand();

            SeatInfoDto seatInfoDto = this.GetTestImportHand().SeatInfoListDto.SeatInfoDtos.FirstOrDefault();

            decimal moneyWon = statisticsService.GetMoneyWon(handDto, seatInfoDto);

            decimal expected = 1.99m;
            decimal actual = moneyWon;

            Assert.Equal(expected, actual);
        }

        //decimal GetAggressionFactor(int totalRaises, int totalBets, int totalCalls);
        [Fact]
        public void TestGetAggressionFactor_WithTotalRaisesOnly_ShouldReturnCorrectAggressionFactor()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            int totalRaises = 2;
            int totalBets = 0;
            int totalCalls = 0;
            decimal aggressionFactor = statisticsService.GetAggressionFactor(totalRaises, totalBets, totalCalls);

            decimal expected = 2m;
            decimal actual = aggressionFactor;

            Assert.Equal(expected, actual);
        }

        //bool GetFourBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);
        [Fact]
        public void TestGetFourBet_WithNoFourBet_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            List<BettingActionDto> playerPreflopBettingActions = this.GetBettingActionDtos();
            string playerName = "Sigtip";
            bool fourBet = statisticsService.GetFourBet(playerPreflopBettingActions, playerName);

            bool expected = false;
            bool actual = fourBet;

            Assert.Equal(expected, actual);
        }

        //bool GetThreeBet(List<BettingActionDto> playerPreflopBettingActions, string playerName);

        [Fact]
        public void TestGetThreeBet_WithNoThreeBet_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            List<BettingActionDto> playerPreflopBettingActions = this.GetBettingActionDtos();
            string playerName = "Sigtip";
            bool threeBet = statisticsService.GetThreeBet(playerPreflopBettingActions, playerName);

            bool expected = false;
            bool actual = threeBet;

            Assert.Equal(expected, actual);
        }




        //bool GetVoluntaryPutMoneyInPot(List<BettingActionDto> playerPreflopBettingActions);
        //IQueryable<StatisticsDto> GetStatisticsById(params long[] statisticsIds);

        //bool GetPreFlopRaise(List<BettingActionDto> playerPreflopBettingActions);
        [Fact]
        public void TestGetPreFlopRaise_WithNoPreFlopRaise_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            List<BettingActionDto> playerPreflopBettingActions = this.GetBettingActionDtos();

            bool preflopRaise = statisticsService.GetPreFlopRaise(playerPreflopBettingActions);

            bool expected = false;
            bool actual = preflopRaise;

            Assert.Equal(expected, actual);
        }

        //IQueryable<StatisticsDto> GetStatisticsById(params long[] statisticsIds);

        //bool GetVoluntaryPutMoneyInPot(List<BettingActionDto> playerPreflopBettingActions);
        [Fact]
        public void TestGetVoluntaryPutMoneyInPot_WithNoVoluntaryPutMoneyInPot_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            List<BettingActionDto> playerPreflopBettingActions = this.GetBettingActionDtos();

            bool voluntaryPutMoneyInPot = statisticsService.GetVoluntaryPutMoneyInPot(playerPreflopBettingActions);

            bool expected = false;
            bool actual = voluntaryPutMoneyInPot;

            Assert.Equal(expected, actual);
        }

        //IQueryable<StatisticsDto> GetStatisticsById(params long[] statisticsIds);

        [Fact]
        public void TestGetStatisticsById_WithOneStatisticId_ShouldReturnCorrectStatisticDto()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StatisticsService statisticsService = new StatisticsService(context);

            ImportHandDto handDto = this.GetTestImportHand();

            Dictionary<string, long> statisticsIdsByPlayerName = statisticsService.AddStatistics(handDto);
            string playerName = "Sigtip";
            long statisticsId = statisticsIdsByPlayerName[playerName];
            StatisticsDto statisticsDto = statisticsService.GetStatisticsById(statisticsId).FirstOrDefault();

            Assert.NotNull(statisticsDto);
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
                        },
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

        private List<BettingActionDto> GetBettingActionDtos()
        {
            List<BettingActionDto> bettingActionDtos = new List<BettingActionDto>()
            {
                new BettingActionDto()
                {
                    Action = "fold",
                    PlayerName = "Sigtip",
                }
            };
            return bettingActionDtos;
        }
    }
}
