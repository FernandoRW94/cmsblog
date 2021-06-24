using System.Collections.Generic;

namespace OrchardCoreCodeDriven.Models
{
    public class ContentPartFieldDefinitionRecord
    {
        public string FieldName { get; set; }

        public string Name { get; set; }

        public List<ContentPartFieldDefinitionRecordSettings> Settings { get; set; }
    }
}
