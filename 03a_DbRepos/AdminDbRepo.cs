using System.Data;
using Configuration;
using DbContext;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Seido.Utilities.SeedGenerator;

namespace DbRepos;

public class AdminDbRepo
{
    private const string _seedSource = "./app-seeds.json";
    private readonly ILogger<AdminDbRepo> _logger;
    private Encryptions _encryptions;
    private readonly MainDbContext _dbContext;

    public async Task SeedAsync(int nrItems)
    {
        //Create a seeder
        var fn = Path.GetFullPath(_seedSource);
        var seeder = new SeedGenerator(fn);

        // Basic seeding of models
        var attractions = seeder.ItemsToList<AttractionDbm>(nrItems);
        var users = seeder.ItemsToList<UserDbm>(nrItems);
        var ratings = seeder.ItemsToList<RatingDbm>(nrItems);
        var comments = seeder.ItemsToList<CommentDbm>(nrItems);
        var cities = seeder.UniqueItemsToList<CityDbm>(nrItems);
        var countries = seeder.UniqueItemsToList<CountryDbm>(nrItems);
        var addresses = seeder.UniqueItemsToList<AddressDbm>(nrItems);

        // Setting relationships between models
        ratings.ForEach(r =>
        {
            r.AttractionDbm = seeder.FromList(attractions);
            r.UserDbm = seeder.FromList(users);
        });
        comments.ForEach(c =>
        {
            c.AttractionDbm = seeder.FromList(attractions);
            c.UserDbm = seeder.FromList(users);
        });
        cities.ForEach(c => c.CountryDbm = seeder.FromList(countries));
        addresses.ForEach(a => a.CityDbm = seeder.FromList(cities));
        attractions.ForEach(a => a.AddressDbm = seeder.FromList(addresses));

        // Adding models to DbSets
        _dbContext.Attractions.AddRange(attractions);
        _dbContext.Users.AddRange(users);
        _dbContext.Ratings.AddRange(ratings);
        _dbContext.Comments.AddRange(comments);
        _dbContext.Cities.AddRange(cities);
        _dbContext.Countries.AddRange(countries);
        _dbContext.Addresses.AddRange(addresses);

        //Saving changes to the database
        await _dbContext.SaveChangesAsync();
    }

    public AdminDbRepo(ILogger<AdminDbRepo> logger, Encryptions encryptions, MainDbContext context)
    {
        _logger = logger;
        _encryptions = encryptions;
        _dbContext = context;
    }
}
