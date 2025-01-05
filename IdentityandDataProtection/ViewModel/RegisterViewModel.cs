using System.ComponentModel.DataAnnotations;

namespace IdentityandDataProtection.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
