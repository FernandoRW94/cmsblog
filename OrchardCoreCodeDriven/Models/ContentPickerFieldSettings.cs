using System.Collections.Generic;

namespace OrchardCoreCodeDriven.Models
{
    public class ContentPickerFieldSettings
    {
        public bool Required { get; set; }

        public bool DisplayAllContentTypes { get; set; }

        public List<string> DisplayedContentTypes { get; set; }
    }
}
