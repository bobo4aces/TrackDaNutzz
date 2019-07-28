using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.HandPlayers;

namespace TrackDaNutzz.Services.Players
{
    public class PlayersService : IPlayersService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IHandPlayersService handPlayersService;

        public PlayersService(TrackDaNutzzDbContext context, IHandPlayersService handPlayersService)
        {
            this.context = context;
            this.handPlayersService = handPlayersService;
        }

        public Dictionary<string, int> AddPlayers(HandDto handDto, long handId, Dictionary<string, long> statisticsIdsByPlayerName, string userId)
        {
            Dictionary<string, int> playersIdsByName = new Dictionary<string, int>();
            foreach (var seatInfoDto in handDto.SeatInfoListDto.SeatInfoDtos)
            {
                Player player = this.context.Players
                    .SingleOrDefault(p => p.Name == seatInfoDto.PlayerName && p.TrackDaNutzzUserId == userId);
                if (player == null)
                {
                    player = new Player()
                    {
                        Name = seatInfoDto.PlayerName,
                        TrackDaNutzzUserId = userId
                    };
                    this.context.Players.Add(player);
                    this.context.SaveChanges();
                }
                this.handPlayersService.AddHandPlayer(handDto, handId, statisticsIdsByPlayerName, seatInfoDto, player);
                playersIdsByName.Add(player.Name, player.Id);
            }
            return playersIdsByName;
        }
        
    }
}
