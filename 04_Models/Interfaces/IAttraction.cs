namespace Models;

public interface IAttraction
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IAddress Address { get; set; }
    public List<IComment> Comments { get; set; }
    public List<IRating> Ratings { get; set; }
    public AttractionType Type { get; set; }
}

public enum AttractionType
{
    Museum,
    Park,
    Monument,
    Historical_Site,
    Amusement_Park,
    Zoo,
    Aquarium,
    Botanical_Garden,
    Art_Gallery,
    Theater,
    Sports_Venue,
    Shopping_Mall,
    Beach,
    Mountain,
    Lake,
    River,
    Island,
    Cultural_Center,
    Observatory,
}
