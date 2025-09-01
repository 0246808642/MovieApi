using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.Dtos.AddressDtos
{
    public class UpdateAddressDto
    {
        [Required]
        public string? PublicPlace { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
