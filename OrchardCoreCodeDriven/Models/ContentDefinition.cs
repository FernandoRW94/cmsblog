using System;
using System.Collections.Generic;

namespace OrchardCoreCodeDriven.Models
{
    public class ContentDefinition
    {
        public string Identifier { get; set; }

        public List<ContentTypeDefinitionRecord> ContentTypeDefinitionRecords { get; set; }

        public List<ContentPartDefinitionRecord> ContentPartDefinitionRecords { get; set; }
    }
}
