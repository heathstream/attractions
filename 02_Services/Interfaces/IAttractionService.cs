using DbModels;
using DbRepos;

namespace Services;

public interface IAttractionService
{
    public Task<IEnumerable<AttractionDbm>> ReadAttractionsAsync();
    public Task<AttractionDbm> ReadAttractionAsync(string idOrName);
}
