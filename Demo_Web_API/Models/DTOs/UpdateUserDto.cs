using System.ComponentModel.DataAnnotations;

namespace Demo_Web_API.Models.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; }
    }
}
