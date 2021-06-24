using CmsBlogWeb.Models.FormModels;

namespace CmsBlogWeb.Models.ViewModels
{
    public class NewStoryPageViewModel : PageViewModel
    {
        public NewStoryPageViewModel()
        {
            this.FormModel = new StoryFormModel();
        }

        public StoryFormModel FormModel { get; set; }
    }
}
