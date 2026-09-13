namespace Models;

public class ResponseItemDto<T>
{
    public T Item { get; set; }
    public int ItemsInDatabase { get; set; }
}
