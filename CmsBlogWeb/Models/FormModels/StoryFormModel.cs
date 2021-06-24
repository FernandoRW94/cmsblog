using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CmsBlogWeb.Models.FormModels
{
    public class StoryFormModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Categories { get; set; }

        [Required]
        public string Content { get; set; }

        [HiddenInput]
        public bool IsEdit { get; set; }

        [HiddenInput]
        public string StoryId { get; set; }

        public List<SelectListItem> CategoriesList { get; set; }
    }
}
