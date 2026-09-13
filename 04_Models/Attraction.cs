using Seido.Utilities.SeedGenerator;

namespace Models;

public class Attraction : IAttraction, ISeed<Attraction>
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; } = "";
    public virtual string Description { get; set; }
    public virtual IAddress Address { get; set; }
    public virtual List<IComment> Comments { get; set; }
    public virtual List<IRating> Ratings { get; set; }
    public virtual AttractionType Type { get; set; }

    public bool Seeded { get; set; }

    public virtual Attraction Seed(SeedGenerator seeder)
    {
        Seeded = true;
        Description = seeder.LatinParagraph;
        Type = seeder.FromEnum<AttractionType>();

        var nrOfNameParts = seeder.Next(1, 4);
        for (int i = 0; i < nrOfNameParts; i++)
            Name += seeder.LatinWords(1).First().ToTitleCase() + " ";
        Name += Type.ToString().Replace("_", " ");
        return this;
    }

    public Attraction() { }

    public Attraction(Attraction org)
    {
        Name = org.Name;
        Description = org.Description;
        Address = org.Address;
        Comments = org.Comments;
        Ratings = org.Ratings;
        Type = org.Type;
    }
}
