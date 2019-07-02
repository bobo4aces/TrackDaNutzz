using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrackDaNutzz.Controllers
{
    public class HandHistoryController : Controller
    {
        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Export()
        {
            return View();
        }
    }
}