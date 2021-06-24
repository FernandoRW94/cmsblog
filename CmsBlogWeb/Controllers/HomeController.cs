using CmsBlogWeb.Business;
using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore;
using OrchardCore.Users;
using OrchardCore.Users.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CmsBlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrchardCoreUserService _orchardCoreUserService;
        private readonly IOrchardCoreContentService _orchardCoreContentService;

        private readonly SignInManager<IUser> _signInManager;

        public HomeController(
            ILogger<HomeController> logger,
            IOrchardCoreUserService orchardCoreUserService,
            IOrchardCoreContentService orchardCoreContentHelperService,
            SignInManager<IUser> signInManager)
        {
            _logger = logger;
            _orchardCoreUserService = orchardCoreUserService;
            _orchardCoreContentService = orchardCoreContentHelperService;
            _signInManager = signInManager;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            var model = await _orchardCoreContentService.GetTypedObject<HomePageViewModel>(Constants.PageAliases.HomePage);

            return View(model);
        }

        [HttpGet("/privacy")]
        public async Task<IActionResult> Privacy()
        {
            var privacyViewModel = await _orchardCoreContentService.GetTypedObject<PrivacyPageViewModel>(Constants.PageAliases.PrivacyPage);

            return View(privacyViewModel);
        }

        [HttpGet("/logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
