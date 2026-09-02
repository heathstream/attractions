using Seido.Utilities.SeedGenerator;

namespace Models;

public class Attraction : IAttraction, ISeed<Attraction>
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual IAddress Address { get; set; }
    public virtual List<IComment> Comments { get; set; }
    public virtual List<IRating> Ratings { get; set; }

    public bool Seeded { get; set; }

    public virtual Attraction Seed(SeedGenerator seeder)
    {
        Name = seeder.LatinWords(1)[0] + " " + seeder.LatinWords(1)[0];
        Description = seeder.LatinParagraph;
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
