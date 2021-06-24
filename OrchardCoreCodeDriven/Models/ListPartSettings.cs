using System.Collections.Generic;

namespace OrchardCoreCodeDriven.Models
{
    public class ListPartSettings
    {
        public int PageSize { get; set; }

        public List<string> ContainedContentTypes { get; set; }

        public bool EnableOrdering { get; set; }
    }
}
