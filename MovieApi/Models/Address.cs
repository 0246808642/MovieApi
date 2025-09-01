using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? PublicPlace { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
