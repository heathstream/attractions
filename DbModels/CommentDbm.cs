using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class CommentDbm : Comment, ISeed<CommentDbm>
{
    public Guid Id { get; set; }

    [NotMapped]
    public override IAttraction Attraction
    {
        get => AttractionDbm;
        set => throw new NotImplementedException();
    }
    public AttractionDbm AttractionDbm { get; set; }

    public override CommentDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
