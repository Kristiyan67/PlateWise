using System.ComponentModel.DataAnnotations;
using PlateWise.Common.Constants;

namespace PlateWise.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(ValidationConstants.User.EmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
