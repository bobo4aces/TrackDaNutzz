using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrackDaNutzz.Controllers
{
    public class HandsController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}