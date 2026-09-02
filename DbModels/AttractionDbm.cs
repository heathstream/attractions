namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

public class AttractionDbm : Attraction, ISeed<AttractionDbm>
{
    [Key]
    public override Guid Id { get; set; }

    [NotMapped]
    public override List<IComment> Comments
    {
        get => CommentsDbm?.ToList<IComment>();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public List<CommentDbm> CommentsDbm { get; set; }

    [NotMapped]
    public override List<IRating> Ratings
    {
        get => RatingsDbm?.ToList<IRating>();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public List<RatingDbm> RatingsDbm { get; set; }

    public override AttractionDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }

    [NotMapped]
    public override IAddress Address
    {
        get => AddressDbm;
        set => throw new NotImplementedException();
    }

    [ForeignKey("AddressId")]
    [JsonIgnore]
    public AddressDbm AddressDbm { get; set; }
}
