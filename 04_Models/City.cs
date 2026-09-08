using Seido.Utilities.SeedGenerator;

namespace Models;

public class City : ICity, ISeed<City>, IEquatable<City>
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual ICountry Country { get; set; }
    public virtual List<IAddress> Addresses { get; set; }
    public bool Seeded { get; set; }

    public bool Equals(City other) => (Name, Country) == (other.Name, other.Country);

    public virtual City Seed(SeedGenerator seeder)
    {
        Name = seeder.City();
        Seeded = true;
        return this;
    }
}
