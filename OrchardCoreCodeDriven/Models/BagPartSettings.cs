using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCoreCodeDriven.Models
{
    public class BagPartSettings
    {
        public string DisplayType { get; set; }

        public List<string> ContainedContentTypes { get; set; }
    }
}
