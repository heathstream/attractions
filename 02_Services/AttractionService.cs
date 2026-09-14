using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace Services;

public class AttractionService : IAttractionService
{
    readonly AttractionsDbRepo _repo = null;
    readonly ILogger<AttractionService> _logger = null;

    public async Task<ResponseListDto<AttractionDbm>> ReadAsync(
        int page,
        int pageSize,
        bool flat = false
    ) => await _repo.ReadAsync(page, pageSize, flat);

    public async Task<ResponseItemDto<AttractionDbm>> ReadItemAsync(
        string idOrName,
        bool flat = false
    ) => await _repo.ReadItemAsync(idOrName, flat);

    public async Task<ResponseItemDto<AttractionDbm>> DeleteAsync(string idOrName) =>
        await _repo.DeleteAsync(idOrName);

    public AttractionService(AttractionsDbRepo repo)
    {
        _repo = repo;
    }

    public AttractionService(AttractionsDbRepo repo, ILogger<AttractionService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
