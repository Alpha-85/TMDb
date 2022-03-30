using AutoMapper;
using TMDb.Application.Common.Models.MovieModels;
using TMDb.Application.Common.Models.RequestModels;
using TMDb.Domain.Common.Enums;
using TMDb.Domain.Entities;

namespace TMDb.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovieRequestModel, Movie>();
        CreateMap<ActorModel, Actor>();
        CreateMap<GenreType, Genre>();

    }
}
