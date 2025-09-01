using MovieApi.Data.Dtos.AddressDtos;
using MovieApi.Data.Dtos.SessionDtos;

namespace MovieApi.Data.Dtos.CinemaDtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastHourConsult { get; set; }= DateTime.Now;
        public ReadAddressDto AddressDto { get; set; }
        public ICollection<ReadSessionDto> SessionsDto { get; set; }

    }
}
