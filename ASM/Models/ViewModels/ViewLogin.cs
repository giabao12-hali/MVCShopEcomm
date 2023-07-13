using Microsoft.Build.Framework;

namespace ASM.Models.ViewModels
{
    public class ViewLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
