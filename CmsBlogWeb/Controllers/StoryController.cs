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

        [HttpGet("/story/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            return View();
        }

        [Authorize]
        [HttpGet("/new-story")]
        public async Task<IActionResult> NewStory()
        {
            var model = new NewStoryPageViewModel();

            return View(model);
        }

        [Authorize]
        [HttpPost("/new-story")]
        public async Task<IActionResult> NewStory(StoryFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("NewStory");
        }

        [Authorize]
        [HttpGet("/edit-story/{id}")]
        public async Task<IActionResult> EditStory(string id)
        {
            var model = new NewStoryPageViewModel();

            return View(model);
        }

        [Authorize]
        [HttpPost("/edit-story/{id}")]
        public async Task<IActionResult> EditStory(StoryFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("EditStory");
        }

    }
}
