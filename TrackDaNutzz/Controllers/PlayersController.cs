using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Dtos.Statistics;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.ViewModels;

namespace TrackDaNutzz.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPlayersService playersService;
        private readonly IStatisticsService statisticsService;
        private readonly IUsersService usersService;

        public PlayersController(IMapper mapper, IPlayersService playersService, IStatisticsService statisticsService, IUsersService usersService)
        {
            this.mapper = mapper;
            this.playersService = playersService;
            this.statisticsService = statisticsService;
            this.usersService = usersService;
        }
        public IActionResult Index()
        {
            //Dictionary<string, List<decimal>> earningsByPlayerName = new Dictionary<string, List<decimal>>();
            //DataSet dataSet = new DataSet();
            //List<PlayerTotalEarningsDto> playerTotalEarnings = this.playersService
            //    .GetTotalEarningsForAllPlayers()
            //    .OrderBy(x=>x.PlayerName)
            //    .ToList();
            //var myChart = new Chart(width: 600, height: 400)
            //    .AddTitle("Total Earnings By Player")
            //    .AddSeries(
            //        name: "Player",
            //        xValue: playerTotalEarnings.Select(x => x.PlayerName).ToList(),
            //        yValues: playerTotalEarnings.Select(x => x.TotalEarnings).ToList())
            //    .Write();
            //TotalEarningsForAllPlayersViewModel totalEarningsForAllPlayersViewModel = new TotalEarningsForAllPlayersViewModel()
            //{
            //    Chart = myChart
            //};
            //return View(totalEarningsForAllPlayersViewModel);
            //IQueryable<StatisticsAllDto> statisticsAllDtos = this.statisticsService.GetAllStatisticsById();
            string currentUsername = this.usersService.GetCurrentlyLoggedUsername();
            string currentUserId = this.usersService.GetCurrentlyLoggedUserId(currentUsername);

            int[] playerIds = this.playersService
                .GetAllPlayerIds(currentUserId)
                .ToArray();
            IEnumerable<StatisticsAllByPlayerNameViewModel> statisticsAllByPlayerNameViewModels = this.playersService
                .GetAllStatisticsByPlayerId(playerIds)
                .Select(x=>new StatisticsAllByPlayerNameViewModel
                {
                    AggressionFactor = x.AggressionFactor,
                    BigBlindsWon = x.BigBlindsWon,
                    ContinuationBet = x.ContinuationBet,
                    FourBet = x.FourBet,
                    HandsPlayed = x.HandsPlayed,
                    MoneyWon = x.MoneyWon,
                    PlayerName = x.PlayerName,
                    PreFlopRaise = x.PreFlopRaise,
                    ThreeBet = x.ThreeBet,
                    VoluntaryPutMoneyInPot = x.VoluntaryPutMoneyInPot
                })
                .ToList();
            StatisticsAllViewModel statisticsAllViewModel = new StatisticsAllViewModel()
            {
                StatisticsAllByPlayerNameViewModels = statisticsAllByPlayerNameViewModels
            };
            return View(statisticsAllViewModel);
        }
    }
}