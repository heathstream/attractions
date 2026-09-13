using DbContext;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class AttractionsDbRepo
{
    readonly ILogger<AttractionsDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public async Task<IEnumerable<AttractionDbm>> ReadAttractionsAsync()
    {
        return await _dbContext
            .Attractions.AsNoTracking()
            .Include(a => a.AddressDbm)
                .ThenInclude(a => a.CityDbm)
                    .ThenInclude(c => c.CountryDbm)
            .Include(a => a.RatingsDbm)
            .Include(a => a.CommentsDbm)
            .ToListAsync();
    }

    public async Task<AttractionDbm> ReadAttractionAsync(string idOrName)
    {
        return await _dbContext
            .Attractions.AsNoTracking()
            .Where(a => a.Name == idOrName || a.Id.ToString() == idOrName)
            .Include(a => a.AddressDbm)
                .ThenInclude(a => a.CityDbm)
                    .ThenInclude(c => c.CountryDbm)
            .Include(a => a.RatingsDbm)
            .Include(a => a.CommentsDbm)
            .FirstOrDefaultAsync();
    }

    public AttractionsDbRepo(ILogger<AttractionsDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
