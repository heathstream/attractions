using Microsoft.Extensions.DependencyInjection;

namespace Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAddressService, AddressService>();
        serviceCollection.AddScoped<IAdminService, AdminServiceDb>();
        serviceCollection.AddScoped<IAttractionService, AttractionService>();
        serviceCollection.AddScoped<ICityService, CityService>();
        serviceCollection.AddScoped<ICommentService, CommentService>();
        serviceCollection.AddScoped<ICountryService, CountryService>();
        serviceCollection.AddScoped<IRatingService, RatingService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        return serviceCollection;
    }
}
