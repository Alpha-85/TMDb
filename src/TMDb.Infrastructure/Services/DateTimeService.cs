using TMDb.Application.Common.Interfaces;

namespace TMDb.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
