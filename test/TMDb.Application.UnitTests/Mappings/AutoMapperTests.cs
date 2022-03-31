using AutoMapper;
using TMDb.Application.Common.Mappings;
using Xunit;

namespace TMDb.Application.UnitTests.Mappings;

public class AutoMapperTests
{
    [Fact]
    public void AllMappingShouldBeValid()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile<MappingProfile>());

        configuration.AssertConfigurationIsValid();

    }
}
