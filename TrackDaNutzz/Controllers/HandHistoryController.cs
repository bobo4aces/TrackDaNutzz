using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackDaNutzz.BindingModels;
using TrackDaNutzz.Parsers;
using TrackDaNutzz.Readers;
using TrackDaNutzz.ViewModels;

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

        [Authorize]
        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IList<IFormFile> files)
        {
            //TODO: Create better validation
            if (files == null || files.Count == 0 || files.Any(e=>!e.FileName.EndsWith(".txt")))
            {
                return this.View(files);
            }
            int filesCount = 0;
            int handsCount = 0;
            foreach (var file in files)
            {
                //TODO: Handle invalid .txt files
                IEnumerable<string> handHistory = await this.handHistoryReader.ReadAsync(file);
                handsCount += this.parser.ParseHandHistory(handHistory);
                filesCount++;
            }
            return this.Redirect($"/HandHistory/ImportSuccess?filesCount={filesCount}&handsCount={handsCount}");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ImportSuccess(ImportSuccessViewModel importSuccessViewModel)
        {
            return View(importSuccessViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Export()
        {
            return View();
        }
    }
}