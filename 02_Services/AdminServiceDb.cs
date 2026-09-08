using DbModels;
using DbRepos;
using Microsoft.Extensions.Logging;

namespace Services;

public class AdminServiceDb : IAdminService
{
    private readonly AdminDbRepo _repo = null;
    private readonly ILogger<AdminServiceDb> _logger = null;

    public async Task SeedAsync(int nrItems) => await _repo.SeedAsync(nrItems);

    #region constructors
    public AdminServiceDb(AdminDbRepo repo)
    {
        _repo = repo;
    }

    public AdminServiceDb(AdminDbRepo repo, ILogger<AdminServiceDb> logger)
        : this(repo)
    {
        _logger = logger;
    }
    #endregion
}
