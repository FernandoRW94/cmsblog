using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.FormModels;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore.Users;
using System.Threading.Tasks;

namespace CmsBlogWeb.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class StoryController : Controller
    {
        private readonly ILogger<StoryController> _logger;
        private readonly IOrchardCoreUserService _orchardCoreUserService;
        private readonly IOrchardCoreContentService _orchardCoreContentService;

        private readonly SignInManager<IUser> _signInManager;

        public StoryController(
            ILogger<StoryController> logger,
            IOrchardCoreUserService orchardCoreUserService,
            IOrchardCoreContentService orchardCoreContentHelperService,
            SignInManager<IUser> signInManager)
        {
            _logger = logger;
            _orchardCoreUserService = orchardCoreUserService;
            _orchardCoreContentService = orchardCoreContentHelperService;
            _signInManager = signInManager;
        }

        [HttpGet("/new-story")]
        public async Task<IActionResult> Index()
        {
            var model = new NewStoryPageViewModel();

            return View(model);
        }

        [HttpPost("/new-story")]
        public async Task<IActionResult> Index(StoryFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
