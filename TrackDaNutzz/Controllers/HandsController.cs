using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.ViewModels;

namespace TrackDaNutzz.Controllers
{
    public class HandsController : Controller
    {
        private readonly IHandsService handsService;
        private readonly IUsersService usersService;
        private readonly IPlayersService playersService;

        public HandsController(IHandsService handsService, IUsersService usersService, IPlayersService playersService)
        {
            this.handsService = handsService;
            this.usersService = usersService;
            this.playersService = playersService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            //TODO: Use Automapper
            string username = this.usersService.GetCurrentlyLoggedUsername();
            string userId = this.usersService.GetCurrentlyLoggedUserId(username);
            PlayerDto activePlayer = this.playersService.GetActivePlayer(userId);
            if (activePlayer == null)
            {
                return this.View();
            }
            int playerId = activePlayer.Id;
            IEnumerable<HandViewModel> handViewModels = this.handsService.GetAllHandsByPlayerId(playerId)
                .Select(h => new HandViewModel()
                {
                    BoardId = h.BoardId,
                    Button = h.Button,
                    Id = h.Id,
                    LocalTime = h.LocalTime,
                    LocalTimeZone = h.LocalTimeZone,
                    Number = h.Number,
                    Pot = h.Pot,
                    Rake = h.Rake,
                    TableId = h.TableId,
                    Time = h.Time,
                    TimeZone = h.TimeZone,
                }).ToList();
            HandAllViewModel handAllViewModel = new HandAllViewModel()
            {
                HandViewModels = handViewModels,
            };
            return View(handAllViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}