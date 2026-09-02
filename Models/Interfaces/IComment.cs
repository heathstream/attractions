namespace Models;

public interface IComment
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public IAttraction Attraction { get; set; }
    public IUser User { get; set; }
    public DateTime Time { get; set; }
}
