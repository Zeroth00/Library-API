using System.ComponentModel.DataAnnotations;

namespace RestApiProje.ModelsDto
{
    public record CreateUpdateBookModelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public long HolderId { get; set; }



    }
}
