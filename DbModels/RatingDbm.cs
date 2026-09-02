namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

public class RatingDbm : Rating, ISeed<RatingDbm>
{
    [Key]
    public override Guid Id { get; set; }

    [NotMapped]
    public override IUser User { get; set; }

    [ForeignKey("UserId")]
    [JsonIgnore]
    public UserDbm UserDbm { get; set; }

    [NotMapped]
    public override IAttraction Attraction { get; set; }

    [ForeignKey("AttractionDbm")]
    [JsonIgnore]
    public UserDbm AttractionDbm { get; set; }

    public override RatingDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
