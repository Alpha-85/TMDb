using AutoMapper;
using TMDb.Application.Common.Models.MovieModels;
using TMDb.Domain.Entities;

namespace TMDb.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Actor, ActorModel>().ReverseMap();
        CreateMap<Genre, GenreModel>().ReverseMap();
        CreateMap<Movie, MovieModel>().ReverseMap();

    }
}
