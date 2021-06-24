using System.Collections.Generic;

namespace OrchardCoreCodeDriven.Models
{
    public class ContentPartDefinitionRecord
    {
        public string Name { get; set; }

        public ContentPartDefinitionRecordSettings Settings { get; set; }

        public List<ContentPartFieldDefinitionRecord> ContentPartFieldDefinitionRecords { get; set; }
    }
}
