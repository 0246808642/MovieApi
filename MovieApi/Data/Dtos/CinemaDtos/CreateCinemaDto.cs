using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.Dtos.CinemaDtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo name é obrigatório")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Nome deve conter entre 3 a 250 caracteres")]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}
