using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.ViewModels.Players;

namespace TrackDaNutzz.ViewComponents
{
    public class ActivePlayerViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;
        private readonly IPlayersService playersService;

        public ActivePlayerViewComponent(IUsersService usersService, IPlayersService playersService)
        {
            this.usersService = usersService;
            this.playersService = playersService;
        }

        public IViewComponentResult Invoke(string username)
        {
            string userId = this.usersService.GetCurrentlyLoggedUserId(username);
            PlayerDto playerDto = this.playersService.GetActivePlayer(userId);
            if (playerDto == null)
            {
                ActivePlayerViewComponentViewModel activePlayerViewComponentViewModelBlank = new ActivePlayerViewComponentViewModel()
                {
                    PlayerId = 0,
                    PlayerName = "",
                    UserPlayers = this.playersService.GetPlayersByUserId(userId)
                                .Select(p => new ActivePlayerViewModel()
                                {
                                    PlayerId = p.Id,
                                    PlayerName = p.Name,
                                    IsActive = p.IsActive,
                                    UserId = p.UserId
                                })
                                .OrderBy(p => p.PlayerName)
                                .ToList()
                };
                return this.View(activePlayerViewComponentViewModelBlank);
            }
            ActivePlayerViewComponentViewModel activePlayerViewComponentViewModel = new ActivePlayerViewComponentViewModel()
            {
                PlayerId = playerDto.Id,
                PlayerName = playerDto.Name,
                UserPlayers = this.playersService.GetPlayersByUserId(userId)
                                .Select(p => new ActivePlayerViewModel()
                                {
                                    PlayerId = p.Id,
                                    PlayerName = p.Name,
                                    IsActive = p.IsActive,
                                    UserId = p.UserId
                                })
                                .OrderBy(p => p.PlayerName)
                                .ToList()
            };
            return this.View(activePlayerViewComponentViewModel);

        }
    }

    public class ActivePlayerViewComponentViewModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public IEnumerable<ActivePlayerViewModel> UserPlayers { get; set; }
    }
}
