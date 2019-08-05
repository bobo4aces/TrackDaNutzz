using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Players;
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
                        IsActive = false,
                        TrackDaNutzzUserId = userId
                    };
                    this.context.Players.Add(player);
                    this.context.SaveChanges();
                }
                this.handPlayersService.AddHandPlayer(handDto, handId, statisticsIdsByPlayerName, seatInfoDto, player);
                playersIdsByName.Add(player.Name, player.Id);
            }
            bool hasActivePlayer = this.context.Players
                .Any(p => p.Name == seatInfoDto.PlayerName && p.TrackDaNutzzUserId == userId && p.IsActive == true);
            if(!hasActivePlayer)
            {
                Player firstPlayer = this.context.Players
                    .FirstOrDefault(p => p.TrackDaNutzzUserId == userId);
                if(firstPlayer == null)
                {
                    throw new ArgumentException("No players at database");
                }
                firstPlayer.IsActive = true;
                this.context.Players.Update(firstPlayer);
                this.context.SaveChanges();
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

        public IQueryable<StatisticsAllByPlayerNameDto> GetAllStatisticsByPlayerId(int activePlayerId, params int[] playerIds)
        {
            //TODO: Don't use HandPlayer Entity
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

        public IQueryable<int> GetAllPlayerIds(string userId, int activePlayerId)
        {
            long[] handIds = this.handPlayersService.GetAllHandIdsByPlayer(activePlayerId).ToArray();
            int[] playerIdsForActivePlayer = this.handPlayersService.GetAllPlayerIdsByHandId(handIds).ToArray();
            IQueryable<int> playerIds = this.context.Players
                .Where(p => p.TrackDaNutzzUserId == userId && playerIdsForActivePlayer.Contains(p.Id))
                .Select(p => p.Id);
            return playerIds;
        }

        public IEnumerable<StatisticsAllByImportStakeDto> GetPlayerStakeStatistics(int playerId)
        {
            //TODO: Use Automapper
            long[] currentPlayerHandIds = this.handPlayersService.GetAllHandIdsByPlayer(playerId).ToArray();
            int[] currentPlayerTableIds = this.handsService.GetTableIdsByHandId(currentPlayerHandIds).ToArray();
            int[] stakeIds = this.tablesService.GetStakeIdsByTableId(currentPlayerTableIds).ToArray();
            StakeDto[] currentPlayerStakes = this.stakesService.GetStakeByStakeId(stakeIds).ToArray();
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
                    StatisticsDto currentStakeStatisticDto = currentStakeStatisticDtos.SingleOrDefault(s => s.Id == currentStakeStatisticId);
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

        public IQueryable<PlayerDto> GetPlayersByUserId(string userId)
        {
            IQueryable<PlayerDto> playerDtos = this.context.Players
                .Where(p => p.TrackDaNutzzUserId == userId)
                .Select(p => new PlayerDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    UserId = p.TrackDaNutzzUserId
                });
            return playerDtos;
        }
        public bool RemoveActivePlayer(int playerId, string userId)
        {
            Player player = this.context.Players.SingleOrDefault(p => p.Id == playerId && p.TrackDaNutzzUserId == userId);
            if (player == null)
            {
                return false;
            }
            player.IsActive = false;
            this.context.Players.Update(player);
            int changes = this.context.SaveChanges();
            if (changes == 0)
            {
                return false;
            }
            return true;
        }

        public bool RemoveActivePlayer(string userId)
        {
            Player player = this.context.Players.SingleOrDefault(p => p.TrackDaNutzzUserId == userId && p.IsActive);
            if (player == null)
            {
                return false;
            }
            player.IsActive = false;
            this.context.Players.Update(player);
            int changes = this.context.SaveChanges();
            if (changes == 0)
            {
                return false;
            }
            return true;
        }
        public bool ChangeActivePlayer(string userId, int oldPlayerId, int newPlayerId)
        {
            Player oldPlayer = this.context.Players.SingleOrDefault(p => p.Id == oldPlayerId && p.TrackDaNutzzUserId == userId);
            Player newPlayer = this.context.Players.SingleOrDefault(p => p.Id == newPlayerId && p.TrackDaNutzzUserId == userId);
            if (oldPlayer == null || newPlayer == null)
            {
                return false;
            }
            oldPlayer.IsActive = false;
            newPlayer.IsActive = true;
            this.context.Players.UpdateRange(oldPlayer, newPlayer);
            int changes = this.context.SaveChanges();
            if (changes == 0)
            {
                return false;
            }
            return true;
        }
        public bool SetActivePlayer(int playerId, string userId)
        {
            Player player = this.context.Players.SingleOrDefault(p => p.Id == playerId && p.TrackDaNutzzUserId == userId);
            if (player == null)
            {
                return false;
            }
            player.IsActive = true;
            this.context.Players.Update(player);
            int changes = this.context.SaveChanges();
            if (changes == 0)
            {
                return false;
            }
            return true;
        }

        public PlayerDto GetActivePlayer(string userId)
        {
            Player player = this.context.Players.SingleOrDefault(p => p.IsActive && p.TrackDaNutzzUserId == userId);
            if (player == null)
            {
                throw new ArgumentException($"No active player or invalid user id - {userId}");
            }
            PlayerDto playerDto = new PlayerDto()
            {
                Id = player.Id,
                IsActive = player.IsActive,
                Name = player.Name,
                UserId = player.TrackDaNutzzUserId,
            };
            return playerDto;
        }
    }
}
