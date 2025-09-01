using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.Dtos.SessionDtos
{
    public class CreateSessionDto
    {
        [Required(ErrorMessage = "O campo Movie é obrigatório")]
        public int MovieId { get; set; }

    }
}
