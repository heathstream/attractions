namespace Models;

public class ResponseListDto<T>
{
    public List<T> Items { get; init; }
    public int ItemsInDatabase { get; init; }
    public int PageSize { get; init; }
    public int Page { get; init; }
    public int PageCount => (int)Math.Ceiling((double)ItemsInDatabase / PageSize);
}
