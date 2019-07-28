using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.Hands
{
    public interface IHandsService
    {
        long AddHand(HandDto handDto, long? boardId, int tableId);
    }
}
