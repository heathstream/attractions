namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Seido.Utilities.SeedGenerator;

public class AttractionDbm : Attraction, ISeed<AttractionDbm>
{
    [Key]
    public Guid Id { get; set; }

    [NotMapped]
    public override List<IComment> Comments
    {
        get => CommentDbms?.ToList<IComment>();
        set => throw new NotImplementedException();
    }
    public List<CommentDbm> CommentDbms { get; set; }

    public override AttractionDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
