namespace OrchardCoreCodeDriven.Models
{
    public class AutoroutePartSettings
    {
        public string Pattern { get; set; }

        public bool AllowCustomPath { get; set; }

        public bool ShowHomepageOption { get; set; }

        public bool AllowUpdatePath { get; set; }

        public bool AllowDisabled { get; set; }

        public bool AllowRouteContainedItems { get; set; }

        public bool ManageContainedItemRoutes { get; set; }

        public bool AllowAbsolutePath { get; set; }
    }
}
