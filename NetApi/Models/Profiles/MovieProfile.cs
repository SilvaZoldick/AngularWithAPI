using AutoMapper;
using NetApi.Models.DTOs.Movie;
using Data.Models;

namespace NetApi.Models.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDTO, Movie>();
        CreateMap<Movie, ReadMovieDTO>();
        CreateMap<UpdateMovieDTO, Movie>();
    }
}