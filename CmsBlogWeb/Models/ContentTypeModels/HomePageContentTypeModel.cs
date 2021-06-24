using CmsBlogWeb.Models.ContentFieldModels;

namespace CmsBlogWeb.Models.ContentTypeModels
{
    public class HomePageContentTypeModel
    {
        public TextFieldModel HeroTitle { get; set; }

        public MarkdownFieldModel HeroText { get; set; }

        public HtmlFieldModel Introduction { get; set; }
    }
}
