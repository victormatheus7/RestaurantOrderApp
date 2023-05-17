using Microsoft.EntityFrameworkCore;
using RestaurantOrderApp.Domain.Entities;

namespace RestaurantOrderApp.Infrastructure.Database
{
    public class RestaurantOrderContext : DbContext
    {
        public DbSet<TimeOfDay> TimesOfDay { get; set; }

        public DbSet<DishType> DishTypes { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<OrderPossibility> OrderPossibilities { get; set; }

        public RestaurantOrderContext(DbContextOptions options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
