namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

public class AddressDbm : Address, ISeed<AddressDbm>
{
    [Key]
    public override Guid Id { get; set; }

    [NotMapped]
    public override ICity City
    {
        get => CityDbm;
        set => throw new NotImplementedException();
    }

    [ForeignKey("CityId")]
    [JsonIgnore]
    public CityDbm CityDbm { get; set; }

    [NotMapped]
    public override List<IAttraction> Attractions
    {
        get => AttractionsDbm?.ToList<IAttraction>();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public List<AttractionDbm> AttractionsDbm { get; set; }

    public override AddressDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
