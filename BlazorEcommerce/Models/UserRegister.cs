using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Models
{
    public sealed class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 15)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
