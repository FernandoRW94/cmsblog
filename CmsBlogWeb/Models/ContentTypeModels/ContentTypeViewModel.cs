using CmsBlogWeb.Models.ContentPartModels;
using System;

namespace CmsBlogWeb.Models.ContentTypeModels
{
    public class ContentTypeViewModel : ContentPartModel
    {
        public string Author { get; set; }

        public string ContentItemId { get; set; }

        public string ContentType { get; set; }

        public DateTime? CreatedUtc { get; set; }

        public string DisplayText { get; set; }

        public int Id { get; set; }

        public bool Latest { get; set; }

        public DateTime? ModifiedUtc { get; set; }

        public string Owner { get; set; }

        public bool Published { get; set; }

        public DateTime? PublishedUtc { get; set; }
    }
}
