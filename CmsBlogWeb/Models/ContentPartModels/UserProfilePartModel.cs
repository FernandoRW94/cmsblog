using CmsBlogWeb.Models.ContentFieldModels;

namespace CmsBlogWeb.Models.ContentPartModels
{
    public class UserProfilePartModel
    {
        public TextFieldModel FirstName { get; set; }

        public TextFieldModel LastName { get; set; }

        public DateTimeFieldModel DateOfBirth { get; set; }

        public BooleanFieldModel AgreeWithTerms { get; set; }
    }
}
