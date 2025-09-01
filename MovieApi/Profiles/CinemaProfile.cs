using AutoMapper;
using MovieApi.Data.Dtos.CinemaDtos;
using MovieApi.Models;

namespace MovieApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema> ();
            CreateMap<UpdateCinemaDto, Cinema> ();
            CreateMap<Cinema, ReadCinemaDto> ().ForMember(x => x.AddressDto, x => x.MapFrom(x =>x.Address)).ForMember(x=>x.SessionsDto, x=>x.MapFrom(x=>x.Sessions));
        }
    }
}
