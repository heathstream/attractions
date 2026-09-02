using Microsoft.Extensions.DependencyInjection;

namespace DbRepos.Extensions;

public static class DbRepoExtensions
{
    public static IServiceCollection AddDbRepos(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<AddressesDbRepo>();
        serviceCollection.AddScoped<AdminDbRepos>();
        serviceCollection.AddScoped<AttractionsDbRepo>();
        serviceCollection.AddScoped<CitiesDbRepo>();
        serviceCollection.AddScoped<CommentsDbRepo>();
        serviceCollection.AddScoped<CountriesDbRepo>();
        serviceCollection.AddScoped<RatingsDbRepo>();
        serviceCollection.AddScoped<UsersDbRepo>();
        return serviceCollection;
    }
}
