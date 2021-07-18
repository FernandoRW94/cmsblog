using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.FormModels;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore;
using OrchardCore.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesSql.Services;

namespace CmsBlogWeb.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class StoryController : Controller
    {
        private readonly ILogger<StoryController> _logger;
        private readonly IOrchardHelper _orchardHelper;
        private readonly SignInManager<IUser> _signInManager;

        public StoryController(
            ILogger<StoryController> logger,
            IOrchardHelper orchardHelper,
            SignInManager<IUser> signInManager)
        {
            _logger = logger;
            _orchardHelper = orchardHelper;
            _signInManager = signInManager;
        }

        [HttpGet("/story/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var story = await _orchardHelper.GetContentItemByIdAsync(id);

            if(story == null)
            {
                return Redirect("/404");
            }

            var model = new StoryPageViewModel
            {
                Content = story
            };

            var categoriesIds = ((IEnumerable<dynamic>)story.Content.BlogPost.TagsTaxonomy.TermContentItemIds).Select(x => x.ToString());
            var relatedStories = await _orchardHelper.QueryCategorizedContentItemsAsync(
                query => query.Where(
                    index => index.TermContentItemId.IsIn(categoriesIds) && index.ContentItemId != id));
            model.RelatedStories = relatedStories.OrderByDescending(x => x.CreatedUtc).Take(3).ToList();

            return View(model);
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
