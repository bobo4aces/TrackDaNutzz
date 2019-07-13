using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.BindingModels;
using TrackDaNutzz.Parsers;
using TrackDaNutzz.Readers;

namespace TrackDaNutzz.Controllers
{
    public class HandHistoryController : Controller
    {
        private readonly IHandHistoryReader handHistoryReader;
        private readonly IParser parser;

        public HandHistoryController(IHandHistoryReader handHistoryReader, IParser parser)
        {
            this.handHistoryReader = handHistoryReader;
            this.parser = parser;
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                IEnumerable<string> handHistory = await this.handHistoryReader.ReadAsync(file);
                this.parser.ParseHandHistory(handHistory);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Export()
        {
            return View();
        }
    }
}