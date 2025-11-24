namespace Movies.Contracts.Requests;

public class PagedRequest
{
    public const int DEFAULT_PAGE = 1;
    public const int DEFAULT_PAGE_SIZE = 10;

    public int? Page { get; init; } = DEFAULT_PAGE;
    public int? PageSize { get; init; } = DEFAULT_PAGE_SIZE;
}