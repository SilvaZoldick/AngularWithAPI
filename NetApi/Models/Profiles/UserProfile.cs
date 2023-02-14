using AutoMapper;
using NetApi.Models.DTOs.User;
using Data.Models;

namespace NetApi.Models.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<Movie, ReadUserDTO>();
        CreateMap<UpdateUserDTO, Movie>();
    }
}