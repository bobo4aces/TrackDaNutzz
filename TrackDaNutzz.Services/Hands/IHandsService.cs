using System.Linq;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.Hands
{
    public interface IHandsService
    {
        long AddHand(ImportHandDto handDto, long? boardId, int tableId);
        IQueryable<long> GetHandIdsByTableId(params int[] tableIds);
        IQueryable<int> GetTableIdsByHandId(params long[] handIds);
        IQueryable<HandDto> GetAllHandsByPlayerId(int playerId);
    }
}
