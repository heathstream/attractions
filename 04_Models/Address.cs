using Seido.Utilities.SeedGenerator;

namespace Models;

public class Address : IAddress, ISeed<Address>, IEquatable<Address>
{
    public virtual Guid Id { get; set; }
    public virtual string StreetName { get; set; }
    public virtual string StreetNumber { get; set; }
    public virtual string PostCode { get; set; }
    public virtual ICity City { get; set; }
    public virtual List<IAttraction> Attractions { get; set; }
    public bool Seeded { get; set; }

    public bool Equals(Address other) =>
        (StreetName, StreetNumber, City) == (other.StreetName, other.StreetNumber, other.City);

    public virtual Address Seed(SeedGenerator seeder)
    {
        var fullAddress = seeder.StreetAddress();
        StreetName = fullAddress.Where(c => !char.IsNumber(c)).ToString();
        StreetNumber = fullAddress.Where(c => char.IsNumber(c)).ToString();
        PostCode = seeder.ZipCode.ToString();
        Seeded = true;
        return this;
    }
}
