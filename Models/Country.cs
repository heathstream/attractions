using Seido.Utilities.SeedGenerator;

namespace Models;

public class Country : ICountry, ISeed<Country>
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual List<ICity> Cities { get; set; }
    public bool Seeded { get; set; }

    public virtual Country Seed(SeedGenerator seeder)
    {
        Name = seeder.Country;
        Seeded = true;
        return this;
    }
}
