using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace CmsBlogWeb.Models.ViewModels
{
    public class StoryPageViewModel  : PageViewModel
    {
        public List<ContentItem> RelatedStories { get; set; }
    }
}
