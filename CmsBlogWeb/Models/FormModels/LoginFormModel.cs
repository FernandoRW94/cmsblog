using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CmsBlogWeb.Models.FormModels
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}
