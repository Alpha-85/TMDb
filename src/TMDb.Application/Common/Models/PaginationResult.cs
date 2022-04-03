namespace TMDb.Application.Common.Models;

public class PaginationResult<T> where T : class
{
    public int NextPage { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<T> EnumerableQueryResult { get; set; }

    public PaginationResult(int nextPage, int totalCount, IEnumerable<T> enumerable)
    {
        NextPage = nextPage;
        TotalCount = totalCount;
        EnumerableQueryResult = enumerable;
    }
}