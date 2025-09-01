using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo logradouro não poder ser nulo")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "O campo logradouro não pode ter mais de 300 caracteres e tem que ter no minímo 3 caracteres")]
        public string? PublicPlace { get; set; }
        [Required(ErrorMessage ="O campo número não poder ser nulo")]
        public int Number { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
