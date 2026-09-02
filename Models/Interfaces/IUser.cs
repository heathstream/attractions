namespace Models;

public interface IUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public List<IRating> Ratings { get; set; }
    public List<IComment> Comments { get; set; }
}
