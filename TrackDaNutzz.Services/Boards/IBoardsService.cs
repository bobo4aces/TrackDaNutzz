using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Summary;

namespace TrackDaNutzz.Services.Boards
{
    public interface IBoardsService
    {
        long AddBoard(BoardSummaryDto boardSummaryDto);
    }
}
