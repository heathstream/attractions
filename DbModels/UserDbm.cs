namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

public class UserDbm : User, ISeed<UserDbm>
{
    [Key]
    public override Guid Id { get; set; }

    [NotMapped]
    public override List<IRating> Ratings { get; set; }

    [JsonIgnore]
    public List<RatingDbm> RatingsDbm { get; set; }

    [NotMapped]
    public override List<IComment> Comments { get; set; }

    [JsonIgnore]
    public List<CommentDbm> CommentsDbm { get; set; }

    public override UserDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
