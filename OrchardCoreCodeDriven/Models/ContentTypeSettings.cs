namespace OrchardCoreCodeDriven.Models
{
    public class ContentTypeSettings
    {
        public string Stereotype { get; set; }

        public bool Listable { get; set; }

        public bool Draftable { get; set; }

        public bool Versionable { get; set; }

        public bool Securable { get; set; }

        public bool Creatable { get; set; }
    }
}
