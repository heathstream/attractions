using Configuration;
using DbContext.Extensions;
using DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;

namespace DbContext;

//DbContext namespace is a fundamental EFC layer of the database context and is
//used for all Database connection as well as for EFC CodeFirst migration and database updates
public class MainDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    DatabaseConnections _databaseConnections;

    public DbSet<AttractionDbm> Attractions { get; set; }
    public DbSet<CommentDbm> Comments { get; set; }
    public DbSet<RatingDbm> Ratings { get; set; }
    public DbSet<UserDbm> Users { get; set; }
    public DbSet<AddressDbm> Addresses { get; set; }
    public DbSet<CityDbm> Cities { get; set; }
    public DbSet<CountryDbm> Countries { get; set; }

    public MainDbContext() { }

    public MainDbContext(DbContextOptions options, DatabaseConnections databaseConnections)
        : base(options)
    {
        _databaseConnections = databaseConnections;
    }

    public class SqlServerDbContext : MainDbContext
    {
        public SqlServerDbContext() { }

        public SqlServerDbContext(DbContextOptions options, DatabaseConnections databaseConnections)
            : base(options, databaseConnections) { }

        //Used only for CodeFirst Database Migration and database update commands
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder = optionsBuilder.ConfigureForDesignTime(
                    (options, connectionString) =>
                        options.UseSqlServer(
                            connectionString,
                            options => options.EnableRetryOnFailure()
                        )
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HaveColumnType("money");
            configurationBuilder.Properties<string>().HaveColumnType("varchar(200)");

            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add your own modelling based on done migrations
            base.OnModelCreating(modelBuilder);
        }
    }
}
