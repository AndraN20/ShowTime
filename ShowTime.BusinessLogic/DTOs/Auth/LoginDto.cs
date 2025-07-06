
using System.ComponentModel.DataAnnotations;

namespace ShowTime.BusinessLogic.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
