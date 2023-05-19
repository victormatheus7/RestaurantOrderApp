using Microsoft.EntityFrameworkCore;
using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.Infrastructure.Database
{
    public class RestaurantOrderAppContext : DbContext
    {
        public DbSet<TimeOfDay> TimesOfDay { get; set; }

        public DbSet<DishType> DishTypes { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<OrderPossibility> OrderPossibilities { get; set; }

        public DbSet<Order> Orders { get; set; }

        public RestaurantOrderAppContext(DbContextOptions options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
