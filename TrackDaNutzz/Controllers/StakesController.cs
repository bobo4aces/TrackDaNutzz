using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.Services.Dtos.Statistics;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.ViewModels;

namespace TrackDaNutzz.Controllers
{
    public class StakesController : Controller
    {
        private readonly IStakesService stakesService;
        private readonly IPlayersService playersService;
        private readonly IUsersService usersService;

        public StakesController(IStakesService stakesService, IPlayersService playersService, IUsersService usersService)
        {
            this.stakesService = stakesService;
            this.playersService = playersService;
            this.usersService = usersService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            //TODO: Use Automapper
            string username = this.usersService.GetCurrentlyLoggedUsername();
            string userId = this.usersService.GetCurrentlyLoggedUserId(username);
            int playerId = this.playersService.GetActivePlayer(userId).Id;
            IEnumerable<StatisticsByStakeViewModel> statisticsByStakeViewModels = this.playersService.GetPlayerStakeStatistics(playerId)
                .Select(x => new StatisticsByStakeViewModel()
                {
                    BigBlind = x.BigBlind,
                    BigBlindsWon = x.BigBlindsWon,
                    ContinuationBet = x.ContinuationBet,
                    CurrencySymbol = x.CurrencySymbol,
                    FourBet = x.FourBet,
                    HandsPlayed = x.HandsPlayed,
                    MoneyWon = x.MoneyWon,
                    PreFlopRaise = x.PreFlopRaise,
                    SmallBlind = x.SmallBlind,
                    ThreeBet = x.ThreeBet,
                    TotalBets = x.TotalBets,
                    TotalCalls = x.TotalCalls,
                    TotalRaises = x.TotalRaises,
                    VoluntaryPutMoneyInPot = x.VoluntaryPutMoneyInPot,
                })
                .ToArray();
            StatisticsListByStakeViewModel statisticsListByStakeView = new StatisticsListByStakeViewModel()
            {
                StatisticsByStakeViewModels = statisticsByStakeViewModels
            };
            return View(statisticsListByStakeView);
        }
    }
}