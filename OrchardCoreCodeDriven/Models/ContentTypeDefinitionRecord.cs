using System.Collections.Generic;

namespace OrchardCoreCodeDriven.Models
{
    public class ContentTypeDefinitionRecord
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ContentTypeDefinitionRecordSettings Settings { get; set; }

        public List<ContentTypePartDefinitionRecord> ContentTypePartDefinitionRecords { get; set; }
    }
}
