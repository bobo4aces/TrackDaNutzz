using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.ViewModels;

namespace TrackDaNutzz.Controllers
{
    public class HandsController : Controller
    {
        private readonly IHandsService handsService;

        public HandsController(IHandsService handsService)
        {
            this.handsService = handsService;
        }
        public IActionResult All()
        {
            int playerId = 1;
            IEnumerable<HandViewModel> handViewModels = this.handsService.GetAllHandsByPlayerId(playerId)
                .Select( h=> new HandViewModel()
                {
                    BoardId = h.BoardId,
                    Button = h.Button,
                    Id = h.Id,
                    LocalTime = h.LocalTime,
                    LocalTimeZone = h.LocalTimeZone,
                    Number = h.Number,
                    Pot = h.Pot,
                    Rake = h.Rake,
                    TableId = h.TableId,
                    Time = h.Time,
                    TimeZone = h.TimeZone,
                }).ToList();
            HandAllViewModel handAllViewModel = new HandAllViewModel()
            {
                HandViewModels = handViewModels,
            };
            return View(handAllViewModel);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}