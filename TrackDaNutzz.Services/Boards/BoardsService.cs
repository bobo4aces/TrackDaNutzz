using System;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Boards;
using TrackDaNutzz.Services.Dtos.Summary;

namespace TrackDaNutzz.Services.Boards
{
    public class BoardsService : IBoardsService
    {
        private readonly TrackDaNutzzDbContext context;

        public BoardsService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

        public long AddBoard(BoardSummaryDto boardSummaryDto)
        {
            //TODO: Use Automapper
            Board board = new Board()
            {
                Flop = boardSummaryDto.FirstCard == null ? null : $"{boardSummaryDto.FirstCard} {boardSummaryDto.SecondCard} {boardSummaryDto.ThirdCard}",
                Turn = boardSummaryDto.FourthCard,
                River = boardSummaryDto.FifthCard
            };
            Board boardFromDb = this.context.Boards
                .SingleOrDefault(b => b.Flop == board.Flop && b.Turn == board.Turn && b.River == board.River);
            if (boardFromDb != null)
            {
                return boardFromDb.Id;
            }
            this.context.Boards.Add(board);
            this.context.SaveChanges();
            return board.Id;
        }

        public BoardDto GetBoardById(int boardId)
        {
            //TODO: Use Automapper
            Board board = this.context.Boards.SingleOrDefault(b => b.Id == boardId);
            if (board == null)
            {
                throw new ArgumentException($"Invalid board id - {boardId}");
            }
            BoardDto boardDto = new BoardDto()
            {
                Flop = board.Flop,
                Id = board.Id,
                River = board.River,
                Turn = board.Turn,
            };
            return boardDto;
        }
    }
}
