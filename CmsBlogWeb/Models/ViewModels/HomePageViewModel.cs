using CmsBlogWeb.Models.ContentTypeModels;
using System.Collections.Generic;

namespace CmsBlogWeb.Models.ViewModels
{
    public class HomePageViewModel : ContentTypeViewModel
    {
        public HomePageContentTypeModel HomePage { get; set; }

        public List<OrchardCore.ContentManagement.ContentItem> Latest6Stories { get; set; }

        public List<OrchardCore.ContentManagement.ContentItem> Top6Stories { get; set; }
    }
}
