using CmsBlogWeb.Models.ContentPartModels;

namespace CmsBlogWeb.Models.ContentTypeModels
{
    public class UserProfileContentTypeModel : ContentTypeViewModel
    {
        public UserProfilePartModel UserProfile { get; set; }
    }
}
