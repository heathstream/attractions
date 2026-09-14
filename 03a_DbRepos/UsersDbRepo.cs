using DbContext;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace DbRepos;

public class UsersDbRepo
{
    readonly ILogger<UsersDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public async Task<ResponseListDto<UserDbm>> ReadAsync(int page, int pageSize, bool flat = false)
    {
        var query = flat
            ? _dbContext.Users.AsNoTracking()
            : _dbContext
                .Users.AsNoTracking()
                .Include(u => u.CommentsDbm)
                .Include(u => u.RatingsDbm);

        return new ResponseListDto<UserDbm>()
        {
            Items = await query.Skip(page * pageSize).Take(pageSize).ToListAsync(),
            Page = page,
            PageSize = pageSize,
            ItemsInDatabase = await query.CountAsync(),
        };
    }

    public async Task<ResponseItemDto<UserDbm>> ReadItemAsync(string idOrName, bool flat = false)
    {
        var query = flat
            ? _dbContext.Users.AsNoTracking().Where(u => u.Id.ToString() == idOrName)
            : _dbContext
                .Users.AsNoTracking()
                .Where(u => u.Id.ToString() == idOrName)
                .Include(u => u.CommentsDbm)
                .Include(u => u.RatingsDbm);

        return new ResponseItemDto<UserDbm>()
        {
            Item = await query.FirstOrDefaultAsync(),
            ItemsInDatabase = await query.CountAsync(),
        };
    }

    public async Task<ResponseItemDto<UserDbm>> DeleteAsync(string idOrName)
    {
        var query = _dbContext
            .Users.AsNoTracking()
            .Where(u => u.Id.ToString() == idOrName)
            .Include(u => u.CommentsDbm)
            .Include(u => u.RatingsDbm);

        var responseItem = new ResponseItemDto<UserDbm>()
        {
            Item = await query.FirstOrDefaultAsync(),
            ItemsInDatabase = await query.CountAsync(),
        };

        _dbContext.Users.Remove(responseItem.Item);
        await _dbContext.SaveChangesAsync();
        return responseItem;
    }

    public UsersDbRepo(ILogger<UsersDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
