using CmsBlogWeb.Business;
using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.Entities;
using OrchardCore.Settings;
using System.Threading.Tasks;

namespace CmsBlogWeb.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IOrchardCoreContentService _orchardCoreContentService;
        private readonly ISiteService _siteService;
        private readonly IOrchardHelper _orchardHelper;

        public HeaderViewComponent(IOrchardCoreContentService orchardCoreContentService, ISiteService siteService, IOrchardHelper orchardHelper)
        {
            _orchardCoreContentService = orchardCoreContentService;
            _siteService = siteService;
            _orchardHelper = orchardHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var site = await _siteService.GetSiteSettingsAsync();
            var headerSettings = site.As<ContentItem>(Constants.ContentTypes.Header);
            
            var model = _orchardCoreContentService.GetTypedObject<HeaderViewModel>(headerSettings);

            return View(model);
        }
    }
}
