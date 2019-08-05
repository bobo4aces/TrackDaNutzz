using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TrackDaNutzz.Services.Common.Enums;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Users;

namespace TrackDaNutzz.ViewComponents
{
    public class WinningsViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;
        private readonly IHandPlayersService handPlayersService;
        private readonly IPlayersService playersService;

        public WinningsViewComponent(IUsersService usersService, IPlayersService playersService, IHandPlayersService handPlayersService)
        {
            this.usersService = usersService;
            this.handPlayersService = handPlayersService;
            this.playersService = playersService;
        }
        public IViewComponentResult Invoke(string username, WinningsType winningsType, TotalAverage totalOrAverage, TimePeriod timePeriod, int timePeriodCount)
        {
            string userId = this.usersService.GetCurrentlyLoggedUserId(username);
            PlayerDto playerDto = this.playersService.GetActivePlayer(userId);
            decimal winnings = this.handPlayersService.GetWinnings(playerDto.Id, winningsType, totalOrAverage, timePeriod, timePeriodCount);
            WinningsViewComponentViewModel winningsViewComponentViewModel = new WinningsViewComponentViewModel()
            {
                Winnings = winnings,
                WinningsType = Enum.GetName(typeof(WinningsType), winningsType),
                TimePeriodCount = timePeriodCount,
                TimePeriod = Enum.GetName(typeof(TimePeriod), timePeriod),
                TotalOrAverage = Enum.GetName(typeof(TotalAverage), totalOrAverage),
            };
            return this.View(winningsViewComponentViewModel);
        }
    }
    public class WinningsViewComponentViewModel
    {
        private string winningsType;

        public string WinningsType
        {
            get
            {
                return this.winningsType;
            }
            set
            {
                string str = string.Empty;
                char[] arr = value.ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (char.IsUpper(arr[i]))
                    {
                        str += $" {arr[i]}";
                    }
                    else
                    {
                        str += arr[i];
                    }
                }
                this.winningsType = str.Trim();
            }
        }
        public decimal Winnings { get; set; }
        public int TimePeriodCount { get; set; }
        public string TimePeriod { get; set; }
        public string TotalOrAverage { get; set; }
    }
}
