using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="O campo name é obrigatório")]
    [StringLength(250, MinimumLength = 3, ErrorMessage = "Nome deve conter entre 3 a 250 caracteres")]
    public string Name { get; set; }

    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
}
