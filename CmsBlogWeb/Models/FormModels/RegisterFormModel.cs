using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CmsBlogWeb.Models.FormModels
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }

        [HiddenInput]
        public bool IsTrue { get { return true; } }

        [Compare("IsTrue", ErrorMessage = "Please agree with the terms and conditions.")]
        public bool AgreeWithTerms { get; set; }

        [HiddenInput]
        public string SubmitButtonText { get; set; }

        [HiddenInput]
        public string FormTitleText { get; set; }
    }
}
