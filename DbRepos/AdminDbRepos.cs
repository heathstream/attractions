using System.Data;
using Configuration;
using DbContext;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seido.Utilities.SeedGenerator;

namespace DbRepos;

public class AdminDbRepos
{
    private const string _seedSource = "./app-seeds.json";
    private readonly ILogger<AdminDbRepos> _logger;
    private Encryptions _encryptions;
    private readonly MainDbContext _dbContext;

    public async Task SeedAsync(int nrItems)
    {
        //Create a seeder
        var fn = Path.GetFullPath(_seedSource);
        var seeder = new SeedGenerator(fn);

        // Seeding credit cards
        var attractions = seeder.ItemsToList<AttractionDbm>(nrItems);
        _dbContext.Attractions.AddRange(attractions);

        //Save changes to the database
        await _dbContext.SaveChangesAsync();
    }

    public AdminDbRepos(
        ILogger<AdminDbRepos> logger,
        Encryptions encryptions,
        MainDbContext context
    )
    {
        _logger = logger;
        _encryptions = encryptions;
        _dbContext = context;
    }
}
