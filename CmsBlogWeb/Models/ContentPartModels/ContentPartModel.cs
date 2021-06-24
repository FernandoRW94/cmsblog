namespace CmsBlogWeb.Models.ContentPartModels
{
    public class ContentPartModel
    {
        public AliasPartModel AliasPart { get; set; }

        public BagPartModel BagPart { get; set; }

        public TitlePartModel TitlePart { get; set; }

        public LinkMenuItemPartModel LinkMenuItemPart { get; set; }

        public MenuItemsListPart MenuItemsListPart { get; set; }
    }
}
