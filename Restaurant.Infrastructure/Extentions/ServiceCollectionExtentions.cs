using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Presistence;
using Restaurant.Infrastructure.Repositories;
using Restaurant.Infrastructure.Seeders;

namespace Restaurant.Infrastructure.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            // DB Connection
            var connectionString = configuration.GetConnectionString("RestaurantsDb");
            service.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));

            // Seeder
            service.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

            // Repository
            service.AddScoped<IRestaurantsRepository, RestaurantsRepository>();

        }
    }
}
