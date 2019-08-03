using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.ViewModels.Tables;

namespace TrackDaNutzz.Controllers
{
    public class TablesController : Controller
    {
        private readonly IHandPlayersService handPlayersService;
        private readonly ITablesService tablesService;

        public TablesController(IHandPlayersService handPlayersService, ITablesService tablesService)
        {
            this.handPlayersService = handPlayersService;
            this.tablesService = tablesService;
        }
        public IActionResult Index()
        {
            int playerId = 1;
            long[] handIds = this.handPlayersService.GetAllHandIdsByPlayer(playerId).ToArray();
            int[] tableIds = this.tablesService.GetAllTableIdsByHandIds(handIds).ToArray();

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
        public IActionResult Details(long tableId)
        {
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