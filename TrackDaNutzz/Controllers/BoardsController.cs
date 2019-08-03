using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.Services.Boards;
using TrackDaNutzz.Services.Dtos.Boards;
using TrackDaNutzz.ViewModels.Boards;

namespace TrackDaNutzz.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardsService boardsService;

        public BoardsController(IBoardsService boardsService)
        {
            this.boardsService = boardsService;
        }
        public IActionResult Details(int boardId)
        {
            BoardDto boardDto = this.boardsService.GetBoardById(boardId);
            BoardViewModel boardViewModel = new BoardViewModel()
            {
                Flop = boardDto.Flop,
                Id = boardDto.Id,
                River = boardDto.River,
                Turn = boardDto.Turn,
            };
            return View(boardViewModel);
        }
    }
}