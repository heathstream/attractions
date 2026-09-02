namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

public class CityDbm : City, ISeed<CityDbm>
{
    [Key]
    public override Guid Id { get; set; }

    [NotMapped]
    public override ICountry Country
    {
        get => CountryDbm;
        set => throw new NotImplementedException();
    }

    [ForeignKey("CountryId")]
    [JsonIgnore]
    public CountryDbm CountryDbm { get; set; }

    [NotMapped]
    public override List<IAddress> Addresses
    {
        get => AddressesDbm?.ToList<IAddress>();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public List<AddressDbm> AddressesDbm { get; set; }

    public override CityDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
