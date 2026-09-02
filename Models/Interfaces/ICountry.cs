using Seido.Utilities.SeedGenerator;

namespace Models;

public interface ICountry
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ICity> Cities { get; set; }
}
