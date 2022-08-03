using System.ComponentModel.DataAnnotations;

namespace RestApiProje.ModelsDto
{
    public class CreateUpdateClientModelDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
