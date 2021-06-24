using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore;
using System.Threading.Tasks;
using CmsBlogWeb.Business;

namespace CmsBlogWeb.ViewComponents
{
    public class CategoriesShortcutViewComponent : ViewComponent
    {
        private readonly ILogger<CategoriesShortcutViewComponent> _logger;
        private readonly IOrchardHelper _orchardHelper;
        private readonly IOrchardCoreContentService _orchardCoreContentHelperService;

        public CategoriesShortcutViewComponent(
            ILogger<CategoriesShortcutViewComponent> logger,
            IOrchardHelper orchardHelper,
            IOrchardCoreContentService orchardCoreContentHelperService)
        {
            _logger = logger;
            _orchardHelper = orchardHelper;
            _orchardCoreContentHelperService = orchardCoreContentHelperService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _orchardCoreContentHelperService.GetTypedObject<CategoriesShortcutViewModel>(Constants.ComponentsAliases.CategoriesShortcut);

            return View(model);
        }
    }
}
