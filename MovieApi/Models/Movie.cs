using MovieApi.Data.Dtos.MovieDtos;
using MovieApi.Data.Dtos.SessionDtos;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get;  set; }

    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    [MaxLength(200, ErrorMessage = "Tamanho máximo do titulo é de 200 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage ="O Genêro do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "Tamanho máximo do genêro é de 50 caracteres")]
    public string Genre { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 minutos a 600 minutos")]
    public int Duration { get; set; }

    public virtual ICollection<Session> Sessions { get; set; }
  
}
