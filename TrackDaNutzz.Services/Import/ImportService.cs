using System.Collections.Generic;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.BettingActions;
using TrackDaNutzz.Services.Boards;
using TrackDaNutzz.Services.Clients;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.Services.Variant;

namespace TrackDaNutzz.Services.Import
{
    public class ImportService : IImportService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IStatisticsService statisticsService;
        private readonly IUsersService usersService;
        private readonly ITablesService tablesService;
        private readonly IPlayersService playersService;
        private readonly IVariantsService variantsService;
        private readonly IStakesService stakesService;
        private readonly IHandsService handsService;
        private readonly IBoardsService boardsService;
        private readonly IClientsService clientsService;
        private readonly IBettingActionsService bettingActionsService;

        public ImportService(TrackDaNutzzDbContext context,
            IStatisticsService statisticsService, IUsersService usersService,
            ITablesService tablesService, IPlayersService playersService,
            IVariantsService variantsService, IStakesService stakesService,
            IHandsService handsService, IBoardsService boardsService,
            IClientsService clientsService, IBettingActionsService bettingActionsService)
        {
            this.context = context;
            this.statisticsService = statisticsService;
            this.usersService = usersService;
            this.tablesService = tablesService;
            this.playersService = playersService;
            this.variantsService = variantsService;
            this.stakesService = stakesService;
            this.handsService = handsService;
            this.boardsService = boardsService;
            this.clientsService = clientsService;
            this.bettingActionsService = bettingActionsService;
        }

        public void Add(ImportHandDto handDto)
        {
            long? boardId = null;
            if (handDto.BoardSummaryDto.FirstCard != null)
            {
                boardId = this.boardsService.AddBoard(handDto.BoardSummaryDto);
            }
            int clientId = this.clientsService.AddClient(handDto.HandInfoDto);
            int stakeId = this.stakesService.AddStake(handDto.HandInfoDto);
            int variantId = this.variantsService.AddVariant(handDto.HandInfoDto);
            int tableId = this.tablesService.AddTable(handDto.ImportTableDto, clientId, stakeId, variantId);
            long handId = this.handsService.AddHand(handDto, boardId, tableId);
            Dictionary<string, long> statisticsIdsByPlayerName = this.statisticsService.AddStatistics(handDto);
            string currentLoggedInUsername = this.usersService.GetCurrentlyLoggedUsername();
            string currentLoggedInUserId = this.usersService.GetCurrentlyLoggedUserId(currentLoggedInUsername);
            Dictionary<string, int> playerIdsByName = this.playersService.AddPlayers(handDto, handId, statisticsIdsByPlayerName, currentLoggedInUserId);
            List<long> bettingActionsIds = this.bettingActionsService.AddBettingActions(handDto, handId, playerIdsByName);
            this.context.SaveChanges();
        }
    }
}
