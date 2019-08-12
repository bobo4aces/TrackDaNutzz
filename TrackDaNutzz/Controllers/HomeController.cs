using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrackDaNutzz.Models;

namespace TrackDaNutzz.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Welcome");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Welcome()
        {
            //TODO: Add yearly, monthly earnings
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
