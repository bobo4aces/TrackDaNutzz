using TrackDaNutzz.Services.Dtos.Boards;
using TrackDaNutzz.Services.Dtos.Summary;

namespace TrackDaNutzz.Services.Boards
{
    public interface IBoardsService
    {
        long AddBoard(BoardSummaryDto boardSummaryDto);

        BoardDto GetBoardById(int boardId);
    }
}
