using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Common;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.HandPlayers;

namespace TrackDaNutzz.Services.BettingActions
{
    public class BettingActionsService : IBettingActionsService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IHandPlayersService handPlayersService;

        public BettingActionsService(TrackDaNutzzDbContext context, IHandPlayersService handPlayersService)
        {
            this.context = context;
            this.handPlayersService = handPlayersService;
        }

        //TODO: don't get handplayer from db
        public List<long> AddBettingActions(ImportHandDto handDto, long handId, Dictionary<string, int> playerIdsByName)
        {
            List<long> bettingActionsIds = new List<long>();
            foreach (var bettingActionsByRoundDto in handDto.BettingActionsByRoundListDto.BettingActionsByRoundDtos)
            {
                foreach (var bettingActionDto in bettingActionsByRoundDto.BettingActionDtos)
                {
                    BettingAction bettingAction = new BettingAction()
                    {
                        Round = bettingActionsByRoundDto.Round,
                        Name = bettingActionDto.Action,
                        Value = bettingActionDto.RaiseTo == null ? bettingActionDto.Value : bettingActionDto.RaiseTo - bettingActionDto.Value,
                        Type = bettingActionDto.Action.Contains(BettingActionNamesConstants.Bet) || bettingActionDto.Action.Contains(BettingActionNamesConstants.Raise)
                    };
                    BettingAction bettingActionFromDb = this.context.BettingActions
                        .SingleOrDefault(x => x.Name == bettingAction.Name &&
                                            x.Round == bettingAction.Round &&
                                            x.Type == bettingAction.Type &&
                                            x.Value == bettingAction.Value);
                    long bettingActionId = 0;
                    string playerName = bettingActionDto.PlayerName;
                    HandPlayer handPlayer = this.context.HandPlayers
                        .FirstOrDefault(x => x.HandId == handId && x.PlayerId == playerIdsByName[playerName]);
                    if (bettingActionFromDb == null)
                    {
                        this.context.BettingActions.Add(bettingAction);
                        this.context.SaveChanges();
                        bettingActionId = bettingAction.Id;
                    }
                    else
                    {
                        bettingActionId = bettingActionFromDb.Id;
                    }
                    this.handPlayersService.AddBettingAction(bettingActionId, handId, playerIdsByName[playerName]);
                    
                    bettingActionsIds.Add(bettingActionId);
                    this.context.SaveChanges();
                }
            }
            return bettingActionsIds;
        }
    }
}
