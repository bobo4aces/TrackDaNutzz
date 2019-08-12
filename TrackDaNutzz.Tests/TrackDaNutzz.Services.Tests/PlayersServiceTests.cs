using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Clients;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.Dtos.Statistics;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.Services.Variant;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class PlayersServiceTests
    {
        //Dictionary<string, int> AddPlayers(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId);
        //IQueryable<StatisticsAllByPlayerNameDto> GetAllStatisticsByPlayerId(int activePlayerId, params int[] playerIds);
        //IQueryable<int> GetAllPlayerIds(string userId, int activePlayerId);
        //IEnumerable<StatisticsAllByImportStakeDto> GetPlayerStakeStatistics(int playerId);
        //IQueryable<PlayerDto> GetPlayersByUserId(string userId);
        //bool RemoveActivePlayer(int playerId, string userId);
        //bool RemoveActivePlayer(string userId);
        //bool ChangeActivePlayer(string userId, int oldPlayerId, int newPlayerId);
        //bool SetActivePlayer(int playerId, string userId);
        //PlayerDto GetActivePlayer(string userId);
        //?bool HasActivePlayer();

        [Fact]
        public void TestAddPlayers_WithOnePlayer_ShouldReturnCorrectPlayer()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);

            long expected = 0;
            long actual = playerIds["Sigtip"];

            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void TestGetAllStatisticsByPlayerId_WithOnePlayer_ShouldReturnCorrectMoneyWon()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int activePlayerId = playerIds["Sigtip"];
            StatisticsAllByPlayerNameDto statisticsAllByPlayerNameDto = playersService.GetAllStatisticsByPlayerId(activePlayerId, playerIds["Sigtip"]).FirstOrDefault();

            decimal expected = 1.99m;
            decimal actual = statisticsAllByPlayerNameDto.MoneyWon;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestGetAllPlayerIds_WithOnePlayer_ShouldReturnCorrectPlayerId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int activePlayerId = playerIds["Sigtip"];
            int playerId = playersService.GetAllPlayerIds(userId, activePlayerId).FirstOrDefault();

            decimal expected = 1;
            decimal actual = playerId;

            Assert.Equal(expected, actual);
        }

        //GetPlayerStakeStatistics(int playerId);

        [Fact]
        public void TestGetPlayerStakeStatistics_WithOnePlayerId_ShouldReturnCorrectStatisticsAllByImportStakeDto()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            int clientId = clientsService.AddClient(importHandDto.HandInfoDto);
            int stakeId = stakesService.AddStake(importHandDto.HandInfoDto);
            int variantId = variantsService.AddVariant(importHandDto.HandInfoDto);
            int tableId = tablesService.AddTable(importHandDto.ImportTableDto, clientId, stakeId, variantId);
            long handId = handsService.AddHand(importHandDto, null, tableId);
            Dictionary<string, long> statisticsIdsByPlayerName = statisticsService.AddStatistics(importHandDto);
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int activePlayerId = playersService.GetActivePlayer(userId).Id;
            StatisticsAllByImportStakeDto statisticsAllByImportStakeDto = playersService.GetPlayerStakeStatistics(activePlayerId).FirstOrDefault();

            decimal expected = 0.02m;
            decimal actual = statisticsAllByImportStakeDto.BigBlind;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetPlayersByUserId_WithOnePlayer_ShouldReturnCorrectCount()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int activePlayerId = playerIds["Sigtip"];
            List<PlayerDto> players = playersService.GetPlayersByUserId(userId).ToList();

            int expected = 1;
            int actual = players.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSetActivePlayer_WithOnePlayer_ShouldReturnTrue()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int playerId = playerIds["Sigtip"];
            bool activePlayer = playersService.SetActivePlayer(playerId, userId);

            bool expected = true;
            bool actual = activePlayer;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRemoveActivePlayer_WithOnePlayer_ShouldReturnTrue()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int playerId = playerIds["Sigtip"];
            bool activePlayer = playersService.SetActivePlayer(playerId, userId);
            bool removedActivePlayer = playersService.RemoveActivePlayer(playerId, userId);
            bool expected = true;
            bool actual = removedActivePlayer;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRemoveActivePlayer_WithUserIdOnly_ShouldReturnTrue()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int playerId = playerIds["Sigtip"];
            bool activePlayer = playersService.SetActivePlayer(playerId, userId);
            bool removedActivePlayer = playersService.RemoveActivePlayer(userId);
            bool expected = true;
            bool actual = removedActivePlayer;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestChangeActivePlayer_WithInvalidPlayerId_ShouldReturnFalse()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int playerId = playerIds["Sigtip"];
            bool activePlayer = playersService.SetActivePlayer(playerId, userId);
            int newPlayerId = 2;
            bool changedActivePlayer = playersService.ChangeActivePlayer(userId, playerId, newPlayerId);
            bool expected = false;
            bool actual = changedActivePlayer;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetActivePlayer_WithOnePlayer_ShouldReturnCorrectName()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            HandPlayersService handPlayersService = new HandPlayersService(context);
            UsersService usersService = new UsersService(context, new FakeSignInManager());
            StatisticsService statisticsService = new StatisticsService(context);
            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            HandsService handsService = new HandsService(context, handPlayersService);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
            PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);

            ImportHandDto importHandDto = this.GetTestImportHand();
            long handId = 1;
            Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
            string userId = Guid.NewGuid().ToString();
            Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
            int playerId = playerIds["Sigtip"];
            bool activePlayer = playersService.SetActivePlayer(playerId, userId);
            PlayerDto player = playersService.GetActivePlayer(userId);
            string expected = "Sigtip";
            string actual = player.Name;

            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void TestHasActivePlayer_WithActivePlayer_ShouldReturnTrue()
        //{
        //    DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
        //        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        //        .Options;
        //    TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
        //
        //    HandPlayersService handPlayersService = new HandPlayersService(context);
        //    UsersService usersService = new UsersService(context, new FakeSignInManager());
        //    StatisticsService statisticsService = new StatisticsService(context);
        //    StakesService stakesService = new StakesService(context);
        //    VariantsService variantsService = new VariantsService(context);
        //    ClientsService clientsService = new ClientsService(context);
        //    HandsService handsService = new HandsService(context, handPlayersService);
        //    TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);
        //    PlayersService playersService = new PlayersService(context, handPlayersService, usersService, statisticsService, tablesService, stakesService, handsService);
        //
        //    ImportHandDto importHandDto = this.GetTestImportHand();
        //    long handId = 1;
        //    Dictionary<string, long> statisticsIdsByPlayerName = this.GetTestStatisticsIdsByPlayerName();
        //    string userId = Guid.NewGuid().ToString();
        //    Dictionary<string, int> playerIds = playersService.AddPlayers(importHandDto, handId, statisticsIdsByPlayerName, userId);
        //    int playerId = playerIds["Sigtip"];
        //    bool activePlayer = playersService.SetActivePlayer(playerId, userId);
        //    bool hasActivePlayer = playersService.HasActivePlayer();
        //    bool expected = true;
        //    bool actual = hasActivePlayer;
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

        private Dictionary<string, long> GetTestStatisticsIdsByPlayerName()
        {
            Dictionary<string, long> statisticsIdsByPlayerName = new Dictionary<string, long>();
            statisticsIdsByPlayerName.Add("Sigtip", 1);
            return statisticsIdsByPlayerName;
        }

    }

    public class FakeSignInManager : SignInManager<TrackDaNutzzUser>
    {
        public FakeSignInManager()
            : base(new FakeUserManager(),
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<TrackDaNutzzUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<TrackDaNutzzUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object)
        { }
    }
    public class FakeUserManager : UserManager<TrackDaNutzzUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<TrackDaNutzzUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<TrackDaNutzzUser>>().Object,
                  new IUserValidator<TrackDaNutzzUser>[0],
                  new IPasswordValidator<TrackDaNutzzUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<TrackDaNutzzUser>>>().Object)
        { }
    }

}
