using Seido.Utilities.SeedGenerator;

namespace Models;

public class Comment : IComment, ISeed<Comment>
{
    public virtual Guid Id { get; set; }
    public virtual string Text { get; set; }
    public virtual IAttraction Attraction { get; set; }
    public virtual IUser User { get; set; }
    public virtual DateTime Time { get; set; }
    public bool Seeded { get; set; }

    public virtual Comment Seed(SeedGenerator seeder)
    {
        Text = seeder.LatinSentence;
        Seeded = true;
        return this;
    }
}
