using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUserContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<UserContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("UserDatabaseConnection"), b => b.MigrationsAssembly("Repository")));
        public static void ConfigureListingContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ListingContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("ListingDatabaseConnection"), b => b.MigrationsAssembly("Repository")));
        public static void ConfigureMortgageApplicationContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<MortgageContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("MortgageApplicationDatabaseConnection"), b => b.MigrationsAssembly("Repository")));
    }
}
