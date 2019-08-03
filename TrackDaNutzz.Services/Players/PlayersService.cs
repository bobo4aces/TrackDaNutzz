using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.Stakes;
using TrackDaNutzz.Services.Dtos.Statistics;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.Services.Users;

namespace TrackDaNutzz.Services.Players
{
    public class PlayersService : IPlayersService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IHandPlayersService handPlayersService;
        private readonly IUsersService usersService;
        private readonly IStatisticsService statisticsService;
        private readonly ITablesService tablesService;
        private readonly IStakesService stakesService;
        private readonly IHandsService handsService;

        public PlayersService(TrackDaNutzzDbContext context, IHandPlayersService handPlayersService, 
            IUsersService usersService, IStatisticsService statisticsService, 
            ITablesService tablesService, IStakesService stakesService,
            IHandsService handsService)
        {
            this.context = context;
            this.handPlayersService = handPlayersService;
            this.usersService = usersService;
            this.statisticsService = statisticsService;
            this.tablesService = tablesService;
            this.stakesService = stakesService;
            this.handsService = handsService;
        }

        public Dictionary<string, int> AddPlayers(ImportHandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId)
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
                this.handPlayersService.AddHandPlayer(handDto, handId, statisticsIdsByPlayerName, seatInfoDto, player);
                playersIdsByName.Add(player.Name, player.Id);
            }
            return playersIdsByName;
        }

        public IQueryable<PlayerTotalEarningsDto> GetTotalEarningsForAllPlayers()
        {
            string currentUsername = this.usersService.GetCurrentlyLoggedUsername();
            string currentUserId = this.usersService.GetCurrentlyLoggedUserId(currentUsername);
            IQueryable<PlayerTotalEarningsDto> playerTotalEarningsDtos = this.context.Players
                .Where(x => x.TrackDaNutzzUserId == currentUserId)
                .Select(x => new PlayerTotalEarningsDto
                {
                    PlayerName = x.Name,
                    TotalEarnings = x.HandPlayers
                            .Where(y => y.PlayerId == x.Id)
                            .Sum(y => y.StackDifference)
                });

            return playerTotalEarningsDtos;
        }

        public IQueryable<StatisticsAllByPlayerNameDto> GetAllStatisticsByPlayerId(params int[] playerIds)
        {
            IQueryable<StatisticsAllByPlayerNameDto> statisticsAllDtos = this.context.Players
                .Where(p => playerIds.Contains(p.Id))
                .Select(x => new StatisticsAllByPlayerNameDto
                {
                    PlayerName = x.Name,
                    TotalRaises = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Sum(y => y.Statistic.TotalRaises),
                    TotalBets = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Sum(y => y.Statistic.TotalBets),
                    TotalCalls = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Sum(y => y.Statistic.TotalCalls),
                    BigBlindsWon = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Sum(y => y.Statistic.BigBlindsWon),
                    ContinuationBet = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Count(y => y.Statistic.ContinuationBet == true),
                    FourBet = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Count(y => y.Statistic.FourBet == true),
                    HandsPlayed = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Count(),
                    MoneyWon = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Sum(y => y.StackDifference),
                    PreFlopRaise = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Count(y => y.Statistic.PreFlopRaise == true),
                    ThreeBet = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Count(y => y.Statistic.ThreeBet == true),
                    VoluntaryPutMoneyInPot = x.HandPlayers
                        .Where(y => y.PlayerId == x.Id)
                        .Count(y => y.Statistic.VoluntaryPutMoneyInPot == true)
                });
            return statisticsAllDtos;
        }

        public IQueryable<int> GetAllPlayerIds(string userId)
        {
            IQueryable<int> playerIds = this.context.Players
                .Where(p => p.TrackDaNutzzUserId == userId)
                .Select(p => p.Id);
            return playerIds;
        }

        public IEnumerable<StatisticsAllByImportStakeDto> GetPlayerStakeStatistics(int playerId)
        {
            long[] currentPlayerHandIds = this.handPlayersService.GetAllHandIdsByPlayer(playerId).ToArray();
            int[] currentPlayerTableIds = this.tablesService.GetAllTableIdsByHandIds(currentPlayerHandIds).ToArray();
            StakeDto[] currentPlayerStakes = this.stakesService.GetStakeByStakeId(currentPlayerTableIds).ToArray();
            List<StatisticsAllByImportStakeDto> statisticsByStakes = new List<StatisticsAllByImportStakeDto>();
            foreach (var stake in currentPlayerStakes)
            {
                int[] currentStakeTableIds = this.tablesService.GetTablesIdsByStakeId(stake.Id).ToArray();
                long[] currentStakeHandIds = this.handsService.GetHandIdsByTableId(currentStakeTableIds).ToArray();
                long[] currentStakeStatisticIds = this.handPlayersService.GetStatisticIdsByPlayerIdAndHandId(playerId, currentStakeHandIds).ToArray();
                HashSet<StatisticsDto> currentStakeStatisticDtos = this.statisticsService.GetStatisticsById(currentStakeStatisticIds).ToHashSet();

                List<StatisticsDto> currentStakeStatisticDtoList = new List<StatisticsDto>();
                foreach (var currentStakeStatisticId in currentStakeStatisticIds)
                {
                    StatisticsDto currentStakeStatisticDto = currentStakeStatisticDtos.SingleOrDefault(s=>s.Id == currentStakeStatisticId);
                    currentStakeStatisticDtoList.Add(currentStakeStatisticDto);
                }

                StatisticsAllByImportStakeDto statisticsByStake = new StatisticsAllByImportStakeDto()
                {
                    SmallBlind = stake.SmallBlind,
                    BigBlind = stake.BigBlind,
                    CurrencySymbol = stake.CurrencySymbol,
                    BigBlindsWon = currentStakeStatisticDtoList.Sum(x => x.BigBlindsWon),
                    ContinuationBet = currentStakeStatisticDtoList.Count(x => x.ContinuationBet),
                    FourBet = currentStakeStatisticDtoList.Count(x => x.FourBet),
                    HandsPlayed = currentStakeStatisticDtoList.Count(),
                    MoneyWon = currentStakeStatisticDtoList.Sum(x => x.MoneyWon),
                    PreFlopRaise = currentStakeStatisticDtoList.Count(x => x.PreFlopRaise),
                    ThreeBet = currentStakeStatisticDtoList.Count(x => x.ThreeBet),
                    TotalBets = currentStakeStatisticDtoList.Sum(x => x.TotalBets),
                    TotalCalls = currentStakeStatisticDtoList.Sum(x => x.TotalCalls),
                    TotalRaises = currentStakeStatisticDtoList.Sum(x => x.TotalRaises),
                    VoluntaryPutMoneyInPot = currentStakeStatisticDtoList.Count(x => x.VoluntaryPutMoneyInPot),
                };
                statisticsByStakes.Add(statisticsByStake);
            }
            return statisticsByStakes;
        }
    }
}