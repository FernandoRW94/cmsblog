namespace OrchardCoreCodeDriven.Models
{
    public class FullTextAspectSettings
    {
        public bool IncludeFullTextTemplate { get; set; }

        public string FullTextTemplate { get; set; }

        public bool IncludeBodyAspect { get; set; }

        public bool IncludeDisplayText { get; set; }
    }
}
