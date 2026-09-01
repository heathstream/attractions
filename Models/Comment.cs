using Seido.Utilities.SeedGenerator;

namespace Models;

public class Comment : IComment, ISeed<Comment>
{
    public string Text { get; set; }
    public bool Seeded { get; set; }
    public virtual IAttraction Attraction { get; set; }

    public virtual Comment Seed(SeedGenerator seeder)
    {
        Text = seeder.LatinSentence;
        Seeded = true;
        return this;
    }

    public Comment() { }

    public Comment(Comment org)
    {
        Text = org.Text;
    }
}
