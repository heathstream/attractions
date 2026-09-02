using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class CommentDbm : Comment, ISeed<CommentDbm>
{
    public override Guid Id { get; set; }

    [NotMapped]
    public override IAttraction Attraction
    {
        get => AttractionDbm;
        set => throw new NotImplementedException();
    }

    [ForeignKey("AttractionId")]
    [JsonIgnore]
    public AttractionDbm AttractionDbm { get; set; }

    [NotMapped]
    public override IUser User
    {
        get => UserDbm;
        set => throw new NotImplementedException();
    }

    [ForeignKey("UserId")]
    [JsonIgnore]
    public UserDbm UserDbm { get; set; }

    public override CommentDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
