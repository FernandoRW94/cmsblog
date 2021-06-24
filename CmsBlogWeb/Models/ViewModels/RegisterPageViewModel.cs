using CmsBlogWeb.Models.ContentTypeModels;
using CmsBlogWeb.Models.FormModels;

namespace CmsBlogWeb.Models.ViewModels
{
    public class RegisterPageViewModel : ContentTypeViewModel
    {
        public RegisterPageViewModel()
        {
            FormModel = new RegisterFormModel();
        }

        public RegisterPageContentTypeModel RegisterPage { get; set; }

        public RegisterFormModel FormModel { get; set; }
    }
}
