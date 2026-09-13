namespace Services;

public interface IAdminService
{
    public Task SeedAsync(
        int attractionsCount,
        int usersCount,
        int citiesCount,
        int countriesCount,
        int addressesCount
    );
}
