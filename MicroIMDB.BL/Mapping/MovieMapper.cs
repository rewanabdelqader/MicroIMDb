using AutoMapper;
using MicroIMDb.Application.Dtos.MovieDto;
using MicroIMDb.Models;


namespace MicroIMDb.Application.Mapping
{
    public class MovieMapper : Profile
    {
        public MovieMapper() { 
        CreateMap<Movie,AddMovieDto>().ReverseMap();
        CreateMap<Movie,GetAllMovies>().ReverseMap();
        CreateMap<Movie,GetMovie>().ReverseMap();
        }
    }
}
