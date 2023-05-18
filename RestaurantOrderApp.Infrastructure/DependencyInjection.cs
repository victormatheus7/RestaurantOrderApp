using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderApp.Domain.Interfaces;
using RestaurantOrderApp.Infrastructure.Database;
using RestaurantOrderApp.Infrastructure.Domain.OrderPossibility;

namespace RestaurantOrderApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RestaurantOrderAppContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default"),
                    a => a.MigrationsAssembly(typeof(RestaurantOrderAppContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IOrderPossibilityRepository, OrderPossibilityRepository>();

            return services;
        }
    }
}