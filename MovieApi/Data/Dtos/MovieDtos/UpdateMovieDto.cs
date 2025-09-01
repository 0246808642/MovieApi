using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.Dtos.MovieDtos
{
    public class UpdateMovieDto
    {
        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        [StringLength(200, ErrorMessage = "Tamanho máximo do titulo é de 200 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O Genêro do filme é obrigatório")]
        [StringLength(50, ErrorMessage = "Tamanho máximo do genêro é de 50 caracteres")]
        public string Genre { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 minutos a 600 minutos")]
        public int Duration { get; set; }
    }
}
