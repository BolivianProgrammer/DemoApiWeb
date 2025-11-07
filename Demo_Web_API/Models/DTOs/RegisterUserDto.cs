using System.ComponentModel.DataAnnotations;

namespace Demo_Web_API.Models.DTOs
{
    public class RegisterUserDto
    {


        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
