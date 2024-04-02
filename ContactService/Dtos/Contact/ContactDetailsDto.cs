using System.ComponentModel.DataAnnotations;
using ContactService.Models;

namespace ContactService.Dtos
{
    public class ContactDetailsDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Subcategory { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{3}$")]
        public string PhoneNumber { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
    }
}