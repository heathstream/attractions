namespace DbModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

public class CountryDbm : Country, ISeed<CountryDbm>, IEquatable<CountryDbm>
{
    [Key]
    public override Guid Id { get; set; }

    [NotMapped]
    public override List<ICity> Cities
    {
        get => CitiesDbm?.ToList<ICity>();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public List<CityDbm> CitiesDbm { get; set; }

    public bool Equals(CountryDbm other) => base.Equals(other);

    public override CountryDbm Seed(SeedGenerator seeder)
    {
        base.Seed(seeder);
        return this;
    }
}
