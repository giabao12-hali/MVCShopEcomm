using Microsoft.Build.Framework;

namespace ASM.Models.ViewModels
{
    public class ViewWebLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
