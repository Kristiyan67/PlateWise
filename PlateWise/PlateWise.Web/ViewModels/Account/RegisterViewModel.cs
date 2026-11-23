using System.ComponentModel.DataAnnotations;
using PlateWise.Common.Constants;

namespace PlateWise.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(
            ValidationConstants.User.DisplayNameMaxLength,
            MinimumLength = ValidationConstants.User.DisplayNameMinLength)]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(ValidationConstants.User.EmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(
            ValidationConstants.User.PasswordMaxLength,
            MinimumLength = ValidationConstants.User.PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
