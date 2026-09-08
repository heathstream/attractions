using Seido.Utilities.SeedGenerator;

namespace Models;

public interface IAddress : ISeed<Address>
{
    public Guid Id { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string PostCode { get; set; }
    public ICity City { get; set; }
    public List<IAttraction> Attractions { get; set; }
}
