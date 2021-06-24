namespace OrchardCoreCodeDriven.Models
{
    public class ContentTypePartDefinitionRecordSettings
    {
        public AliasPartSettings AliasPartSettings { get; set; }
        
        public ContentTypePartSettings ContentTypePartSettings { get; set; }

        public ContentIndexSettings ContentIndexSettings { get; set; }

        public MarkdownBodyPartSettings MarkdownBodyPartSettings { get; set; }

        public TitlePartSettings TitlePartSettings { get; set; }

        public BagPartSettings BagPartSettings { get; set; }

        public AutoroutePartSettings AutoroutePartSettings { get; set; }

        public CommonPartSettings CommonPartSettings { get; set; }

        public FlowPartSettings FlowPartSettings { get; set; }

        public HtmlBodyPartSettings HtmlBodyPartSettings { get; set; }

        public HtmlBodyPartTrumbowygEditorSettings HtmlBodyPartTrumbowygEditorSettings { get; set; }

        public HtmlBodyPartMonacoEditorSettings HtmlBodyPartMonacoEditorSettings { get; set; }

        public HtmlMenuItemPartSettings HtmlMenuItemPartSettings { get; set; }

        public ListPartSettings ListPartSettings { get; set; }

        public PreviewPartSettings PreviewPartSettings { get; set; }

        public WidgetsListPartSettings WidgetsListPartSettings { get; set; }
    }
}
