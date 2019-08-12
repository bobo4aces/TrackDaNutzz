using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Services.Dtos.Players;
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

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            //TODO: Use Automapper
            string currentUsername = this.usersService.GetCurrentlyLoggedUsername();
            string currentUserId = this.usersService.GetCurrentlyLoggedUserId(currentUsername);
            PlayerDto activePlayer = this.playersService.GetActivePlayer(currentUserId);
            if (activePlayer == null)
            {
                return this.View();
            }
            int activePlayerId = activePlayer.Id;
            int[] playerIds = this.playersService
                .GetAllPlayerIds(currentUserId, activePlayerId)
                .ToArray();

            //string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<StatisticsAllByPlayerNameViewModel> statisticsAllByPlayerNameViewModels = this.playersService
                .GetAllStatisticsByPlayerId(activePlayerId, playerIds)
                .Select(x => new StatisticsAllByPlayerNameViewModel
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
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