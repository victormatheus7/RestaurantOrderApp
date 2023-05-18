using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderApp.Infrastructure.Database;

namespace RestaurantOrderApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RestaurantOrderAppContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default"),
                    a => a.MigrationsAssembly(typeof(RestaurantOrderAppContext).Assembly.FullName)), ServiceLifetime.Transient);

            return services;
        }
    }
}