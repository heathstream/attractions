namespace Models;

public class ResponseListDto<T>
{
    public List<T> Results = new();
    public int ItemsInDatabase;
    public int PageSize;
    public int Page;
}
