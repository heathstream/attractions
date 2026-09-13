using DbContext;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace DbRepos;

public class AttractionsDbRepo
{
    readonly ILogger<AttractionsDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public async Task<ResponseListDto<AttractionDbm>> ReadAttractionsAsync(
        int page,
        int pageSize,
        bool flat = false
    )
    {
        var query = flat
            ? _dbContext.Attractions.AsNoTracking()
            : _dbContext
                .Attractions.AsNoTracking()
                .Include(a => a.AddressDbm)
                    .ThenInclude(a => a.CityDbm)
                        .ThenInclude(c => c.CountryDbm)
                .Include(a => a.RatingsDbm)
                .Include(a => a.CommentsDbm);

        return new ResponseListDto<AttractionDbm>()
        {
            Items = await query.Skip(page * pageSize).Take(pageSize).ToListAsync(),
            Page = page,
            PageSize = pageSize,
            ItemsInDatabase = await query.CountAsync(),
        };
    }

    public async Task<ResponseItemDto<AttractionDbm>> ReadAttractionAsync(
        string idOrName,
        bool flat = false
    )
    {
        var query = flat
            ? _dbContext
                .Attractions.AsNoTracking()
                .Where(a => a.Name == idOrName || a.Id.ToString() == idOrName)
            : _dbContext
                .Attractions.AsNoTracking()
                .Where(a => a.Name == idOrName || a.Id.ToString() == idOrName)
                .Include(a => a.AddressDbm)
                    .ThenInclude(a => a.CityDbm)
                        .ThenInclude(c => c.CountryDbm)
                .Include(a => a.RatingsDbm)
                .Include(a => a.CommentsDbm);

        return new ResponseItemDto<AttractionDbm>()
        {
            Item = await query.FirstOrDefaultAsync(),
            ItemsInDatabase = await query.CountAsync(),
        };
    }

    public async Task<ResponseItemDto<AttractionDbm>> DeleteAttractionAsync(string idOrName)
    {
        var query = _dbContext
            .Attractions.AsNoTracking()
            .Where(a => a.Name == idOrName || a.Id.ToString() == idOrName)
            .Include(a => a.AddressDbm)
                .ThenInclude(a => a.CityDbm)
                    .ThenInclude(c => c.CountryDbm)
            .Include(a => a.RatingsDbm)
            .Include(a => a.CommentsDbm);

        var responseItem = new ResponseItemDto<AttractionDbm>()
        {
            Item = await query.FirstOrDefaultAsync(),
            ItemsInDatabase = await query.CountAsync(),
        };

        _dbContext.Attractions.Remove(responseItem.Item);
        await _dbContext.SaveChangesAsync();
        return responseItem;
    }

    public AttractionsDbRepo(ILogger<AttractionsDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
