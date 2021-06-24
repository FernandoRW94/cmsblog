namespace OrchardCoreCodeDriven.Globals
{
    public static class Constants
    {
        public static class Enums
        {
            public enum AliasPartSettingsOptions
            {
                Editable = 0,
                GeneratedDisabled = 1
            }

            public enum TitlePartSettingsOptions
            {
                Editable = 0,
                EditableRequired = 1,
                GeneratedDisabled = 2,
                GeneratedHidden = 3
            }
        }

        public static class Editors
        {
            public const string Wysiwyg = "Wysiwyg";

            public const string Trumbowyg = "Trumbowyg";

            public const string Monaco = "Monaco";
        }
    }
}
