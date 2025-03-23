namespace University.Application.Common;

public class PageResponse<T> where T : class
{
    public int Count { get; init; }

    public T Data { get; init; }
}
