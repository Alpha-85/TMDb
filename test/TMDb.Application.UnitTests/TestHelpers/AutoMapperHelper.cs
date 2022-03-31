using AutoMapper;
using TMDb.Application.Common.Mappings;

namespace TMDb.Application.UnitTests.TestHelpers;

public static class AutoMapperHelper
{
    public static IMapper GetAutoMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        var mapper = config.CreateMapper();

        return mapper;
    }
}
