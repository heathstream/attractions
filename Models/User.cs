using Seido.Utilities.SeedGenerator;

namespace Models;

public class User : IUser, ISeed<User>
{
    public virtual Guid Id { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string FullName => $"{FirstName} {LastName}";

    public virtual List<IRating> Ratings { get; set; } = new();
    public virtual List<IComment> Comments { get; set; } = new();

    public bool Seeded { get; set; }

    public virtual User Seed(SeedGenerator seeder)
    {
        FirstName = seeder.FirstName;
        LastName = seeder.LastName;
        Seeded = true;
        return this;
    }
}
