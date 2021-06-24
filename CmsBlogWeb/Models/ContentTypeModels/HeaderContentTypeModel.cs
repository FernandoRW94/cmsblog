using CmsBlogWeb.Models.ContentFieldModels;

namespace CmsBlogWeb.Models.ContentTypeModels
{
    public class HeaderContentTypeModel
    {
        public TextFieldModel LoginButtonText { get; set; }

        public TextFieldModel LogoutButtonText { get; set; }

        public TextFieldModel RegisterButtonText { get; set; }

        public TextFieldModel SearchPlaceholder { get; set; }

        public TextFieldModel DashboardButtonText { get; set; }

        public TextFieldModel NewPostButtonText { get; set; }

        public TextFieldModel ProfileButtonText { get; set; }
    }
}
