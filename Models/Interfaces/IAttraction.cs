namespace Models;

public interface IAttraction
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IAddress Address { get; set; }
}
