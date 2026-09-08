namespace Models;

public interface IRating
{
    public Guid Id { get; set; }
    public IAttraction Attraction { get; set; }
    public IUser User { get; set; }
    public DateTime Time { get; set; }
    public int Score { get; set; }
}
