using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TrackDaNutzz.Data.Models;

namespace TrackDaNutzz.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<TrackDaNutzzUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<TrackDaNutzzUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            if (_signInManager.Context.User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                return Redirect("/Identity/Account/Logout");
            }
            else
            {
                return Page();
            }
        }
    }
}