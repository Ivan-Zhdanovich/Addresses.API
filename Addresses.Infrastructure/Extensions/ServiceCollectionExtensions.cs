using Addresses.Domain.Entities;
using Addresses.Infrastructure.Persistence;
using Addresses.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Addresses.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("WorkDb");
            services.AddDbContext<AddressesDbContext>(options => options.UseNpgsql(connectionString)
                .EnableSensitiveDataLogging());


            services.AddScoped<IAddressSeeder, AddressSeeder>();
        }
    }
}
