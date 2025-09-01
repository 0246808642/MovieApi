using AutoMapper;
using MovieApi.Data.Dtos.MovieDtos;
using MovieApi.Models;

namespace MovieApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<Movie, ReadMovieDto>().ForMember(x=>x.SessionsDto, x=>x.MapFrom(x=>x.Sessions));
        }

       
    }
}
