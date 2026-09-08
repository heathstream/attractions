using Seido.Utilities.SeedGenerator;

namespace Models;

public class Rating : IRating, ISeed<Rating>
{
    public virtual Guid Id { get; set; }
    public virtual IAttraction Attraction { get; set; }
    public virtual IUser User { get; set; }
    public virtual DateTime Time { get; set; }
    public virtual int Score { get; set; }
    public virtual bool Seeded { get; set; }

    public virtual Rating Seed(SeedGenerator seeder)
    {
        Score = seeder.Next(0, 11);
        Seeded = true;
        return this;
    }
}
