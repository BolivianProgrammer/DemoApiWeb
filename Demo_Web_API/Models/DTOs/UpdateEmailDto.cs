using System.ComponentModel.DataAnnotations;

namespace Demo_Web_API.Models.DTOs
{
    public class UpdateEmailDto
    {
        [Required]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
