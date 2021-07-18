using CmsBlogWeb.Business;
using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore;
using OrchardCore.Users;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YesSql.Services;

namespace CmsBlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrchardCoreUserService _orchardCoreUserService;
        private readonly IOrchardCoreContentService _orchardCoreContentService;
        private readonly IOrchardHelper _orchardHelper;
        private readonly SignInManager<IUser> _signInManager;

        public HomeController(
            ILogger<HomeController> logger,
            IOrchardCoreUserService orchardCoreUserService,
            IOrchardCoreContentService orchardCoreContentService,
            IOrchardHelper orchardHelper,
            SignInManager<IUser> signInManager)
        {
            _logger = logger;
            _orchardCoreUserService = orchardCoreUserService;
            _orchardCoreContentService = orchardCoreContentService;
            _orchardHelper = orchardHelper;
            _signInManager = signInManager;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            var model = await _orchardCoreContentService.GetTypedObject<HomePageViewModel>(Constants.PageAliases.HomePage);

            model.Latest6Stories = (await _orchardHelper.ContentQueryAsync("Latest6Posts")).ToList();

            var top6StoriesParams = new Dictionary<string, object>();
            top6StoriesParams.Add("skip", 0);
            top6StoriesParams.Add("take", 6);

            var top6Stories = await _orchardHelper.QueryResultsAsync("AllPosts", top6StoriesParams);
            model.Latest6Stories = top6Stories.Items.Select(x => x as OrchardCore.ContentManagement.ContentItem).ToList();

            var popularPosts = await _orchardHelper.QueryResultsAsync("PopularPosts", top6StoriesParams);
            model.Top6Stories = popularPosts.Items.Select(x => x as OrchardCore.ContentManagement.ContentItem).ToList();

            //var tags = new List<string> { "Action", "Horror" };
            //var categoriesContentItem = await _orchardHelper.GetContentItemByAliasAsync(Constants.ContentTypes.Categories);
            //var categoriesIds = ((IEnumerable<dynamic>)categoriesContentItem.Content.TaxonomyPart.Terms).Where(x => tags.Contains(x.DisplayText.Value)).Select(y => y.ContentItemId.Value);
            //var postsWithCategories = await _orchardHelper.QueryCategorizedContentItemsAsync(query => query.Where(index => index.TermContentItemId.IsIn(categoriesIds)));

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

