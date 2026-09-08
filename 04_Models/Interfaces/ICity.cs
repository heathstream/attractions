using Seido.Utilities.SeedGenerator;

namespace Models;

public interface ICity : ISeed<City>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICountry Country { get; set; }
    public List<IAddress> Addresses { get; set; }
}
