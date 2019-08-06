using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.BettingActions;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.HandPlayers;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class BettingActionsServiceTests
    {
        //List<long> AddBettingActions(ImportHandDto handDto, long handId, Dictionary<string, int> playerIdsByName);
        [Fact]
        public void TestAddBettingActions_WithOneBettingAction_ShouldReturnCorrectCount()
        {
            var options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
            HandPlayersService handPlayersService = new HandPlayersService(context);

            BettingActionsService bettingActionsService = new BettingActionsService(context, handPlayersService);

            List<long> bettingActionIds = bettingActionsService.AddBettingActions(GetTestImportHandDto(), 1, GetPlayerIdsByName());
            int expected = 1;
            int actual = bettingActionIds.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddBettingActions_WithTwoEqualBettingActions_ShouldReturnCorrectCount()
        {
            var options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
            HandPlayersService handPlayersService = new HandPlayersService(context);

            BettingActionsService bettingActionsService = new BettingActionsService(context, handPlayersService);

            ImportHandDto importHandDto = GetTestImportHandDto();
            BettingActionsByRoundDto bettingActionsByRoundDtos = importHandDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos.FirstOrDefault();
            importHandDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos.Add(bettingActionsByRoundDtos);
            List<long> bettingActionIds = bettingActionsService.AddBettingActions(GetTestImportHandDto(), 1, GetPlayerIdsByName());
            int expected = 1;
            int actual = bettingActionIds.Count;
            Assert.Equal(expected, actual);
        }
        private ImportHandDto GetTestImportHandDto()
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

                }
            };

            return importHandDto;
        }

        private Dictionary<string, int> GetPlayerIdsByName()
        {
            Dictionary<string, int> playerIdsByName = new Dictionary<string, int>();
            playerIdsByName.Add("Sigtip", 1);
            return playerIdsByName;
        }
    }
}