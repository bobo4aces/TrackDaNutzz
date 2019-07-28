using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
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
    }
}
