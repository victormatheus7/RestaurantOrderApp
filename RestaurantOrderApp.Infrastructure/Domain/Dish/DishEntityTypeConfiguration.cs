using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantOrderApp.Infrastructure.Domain.Dish
{
    internal sealed class DishEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantOrderApp.Domain.Entities.Dish>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderApp.Domain.Entities.Dish> builder)
        {
            builder.ToTable("dishes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().HasColumnName("id");
            builder.Property(x => x.Name).HasMaxLength(50).HasColumnName("name");
            builder.Property(x => x.ModifiedDate).HasColumnName("modified_date").HasDefaultValueSql("now()");
            builder.HasData(
                new RestaurantOrderApp.Domain.Entities.Dish(0, "eggs"),
                new RestaurantOrderApp.Domain.Entities.Dish(1, "Toast"),
                new RestaurantOrderApp.Domain.Entities.Dish(2, "coffee"),
                new RestaurantOrderApp.Domain.Entities.Dish(3, "steak"),
                new RestaurantOrderApp.Domain.Entities.Dish(4, "potato"),
                new RestaurantOrderApp.Domain.Entities.Dish(5, "wine"),
                new RestaurantOrderApp.Domain.Entities.Dish(6, "cake")
            );
        }
    }
}
