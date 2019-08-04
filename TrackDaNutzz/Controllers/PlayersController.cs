using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TrackDaNutzz.ViewComponents;
using TrackDaNutzz.ViewModels;
using TrackDaNutzz.ViewModels.Players;

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
            string currentUsername = this.usersService.GetCurrentlyLoggedUsername();
            string currentUserId = this.usersService.GetCurrentlyLoggedUserId(currentUsername);
            int activePlayerId = this.playersService.GetActivePlayer(currentUserId).Id;
            int[] playerIds = this.playersService
                .GetAllPlayerIds(currentUserId, activePlayerId)
                .ToArray();
            IEnumerable<StatisticsAllByPlayerNameViewModel> statisticsAllByPlayerNameViewModels = this.playersService
                .GetAllStatisticsByPlayerId(activePlayerId, playerIds)
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


        [HttpPost]
        public IActionResult ActivePlayer(int playerId)
        {
            string username = this.usersService.GetCurrentlyLoggedUsername();
            string userId = this.usersService.GetCurrentlyLoggedUserId(username);
            int oldPlayerId = this.playersService.GetActivePlayer(userId).Id;
            this.playersService.ChangeActivePlayer(userId, oldPlayerId, playerId);
            string path = Request.Headers["Referer"].ToString();
            return this.Redirect(path);
        }
    }
}