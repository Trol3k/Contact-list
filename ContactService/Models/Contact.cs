using System.ComponentModel.DataAnnotations;

namespace ContactService.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{3}$")]
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}