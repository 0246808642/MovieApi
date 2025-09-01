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
            CreateMap<Cinema, UpdateCinemaDto> ();
            CreateMap<Cinema, ReadCinemaDto> ();
        }
    }
}
