using static OrchardCoreCodeDriven.Globals.Constants.Enums;

namespace OrchardCoreCodeDriven.Models
{
    public class TitlePartSettings
    {
        public bool RenderTitle { get; set; }

        public TitlePartSettingsOptions Options { get; set; }
    }
}
