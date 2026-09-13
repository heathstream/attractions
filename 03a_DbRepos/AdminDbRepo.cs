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

    public async Task SeedAsync(
        int attractionsCount = 1000,
        int usersCount = 50,
        int citiesCount = 100,
        int countriesCount = 4,
        int addressesCount = 1000
    )
    {
        //Create a seeder
        var fn = Path.GetFullPath(_seedSource);
        var seeder = new SeedGenerator(fn);

        // Basic seeding of models
        var attractions = seeder.ItemsToList<AttractionDbm>(attractionsCount);
        var users = seeder.ItemsToList<UserDbm>(usersCount);
        var cities = seeder.UniqueItemsToList<CityDbm>(citiesCount);
        var countries = seeder.UniqueItemsToList<CountryDbm>(countriesCount);
        var addresses = seeder.UniqueItemsToList<AddressDbm>(addressesCount);
        var comments = new List<CommentDbm>();
        var ratings = new List<RatingDbm>();

        // Setting relationships between models

        cities.ForEach(c => c.CountryDbm = seeder.FromList(countries));
        addresses.ForEach(a => a.CityDbm = seeder.FromList(cities));
        attractions.ForEach(a =>
        {
            a.AddressDbm = seeder.FromList(addresses);
            a.CommentsDbm = seeder.ItemsToList<CommentDbm>(seeder.Next(0, 21));
            a.RatingsDbm = seeder.ItemsToList<RatingDbm>(seeder.Next(0, 21));
            comments.AddRange(a.CommentsDbm);
            ratings.AddRange(a.RatingsDbm);
        });

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
