using Seido.Utilities.SeedGenerator;

namespace Models;

public class Attraction : IAttraction, ISeed<Attraction>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public bool Seeded { get; set; }
    public virtual List<IComment> Comments { get; set; }

    public virtual Attraction Seed(SeedGenerator seeder)
    {
        Name = seeder.LatinWords(1)[0] + " " + seeder.LatinWords(1)[0];
        Address = seeder.StreetAddress();
        Seeded = true;
        return this;
    }

    public Attraction() { }

    public Attraction(Attraction org)
    {
        Name = org.Name;
        Address = org.Address;
    }
}
