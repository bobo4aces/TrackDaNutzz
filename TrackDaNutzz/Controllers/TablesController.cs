using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.Services.Dtos.Players;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.ViewModels.Tables;

namespace TrackDaNutzz.Controllers
{
    public class TablesController : Controller
    {
        private readonly IHandPlayersService handPlayersService;
        private readonly ITablesService tablesService;
        private readonly IHandsService handsService;
        private readonly IUsersService usersService;
        private readonly IPlayersService playersService;

        public TablesController(IHandPlayersService handPlayersService, ITablesService tablesService, IHandsService handsService, IUsersService usersService, IPlayersService playersService)
        {
            this.handPlayersService = handPlayersService;
            this.tablesService = tablesService;
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
            long[] handIds = this.handPlayersService.GetAllHandIdsByPlayer(playerId).ToArray();
            int[] tableIds = this.handsService.GetTableIdsByHandId(handIds).ToArray();

            IEnumerable<TableViewModel> tableViewModels = this.tablesService.GetTableById(tableIds)
                .Select(t=> new TableViewModel()
                {
                    BigBlind = t.Stake.BigBlind,
                    ClientName = t.ClientName,
                    Currency = t.Stake.Currency,
                    CurrencySymbol = t.Stake.CurrencySymbol,
                    Id = t.Id,
                    Size = t.Size,
                    SmallBlind = t.Stake.SmallBlind,
                    TableName = t.TableName,
                    VariantLimit = t.Variant.Limit,
                    VariantName = t.Variant.Name,
                }).ToList();
            TableAllViewModel tableAllViewModel = new TableAllViewModel()
            {
                TableViewModels = tableViewModels
            };
            return View(tableAllViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(long tableId)
        {
            //TODO: Use Automapper
            TableDto tableDto = this.tablesService.GetTableById(tableId);
            TableViewModel tableViewModel = new TableViewModel()
            {
                BigBlind = tableDto.Stake.BigBlind,
                ClientName = tableDto.ClientName,
                Currency = tableDto.Stake.Currency,
                CurrencySymbol = tableDto.Stake.CurrencySymbol,
                Id = tableDto.Id,
                Size = tableDto.Size,
                SmallBlind = tableDto.Stake.SmallBlind,
                TableName = tableDto.TableName,
                VariantLimit = tableDto.Variant.Limit,
                VariantName = tableDto.Variant.Name,
            };
            return View(tableViewModel);
        }
    }
}