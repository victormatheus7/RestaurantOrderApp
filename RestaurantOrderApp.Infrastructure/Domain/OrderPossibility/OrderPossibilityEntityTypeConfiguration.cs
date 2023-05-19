using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantOrderApp.Infrastructure.Domain.OrderPossibility
{
    internal sealed class OrderPossibilityEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantOrderApp.Domain.Entities.OrderPossibility>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderApp.Domain.Entities.OrderPossibility> builder)
        {
            builder.ToTable("order_possibilities");
            builder.HasKey(x => new { x.TimeOfDayId, x.DishTypeId });
            builder.Property(x => x.TimeOfDayId).ValueGeneratedNever().HasColumnName("time_of_day_id");
            builder.Property(x => x.DishTypeId).ValueGeneratedNever().HasColumnName("dish_type_id");
            builder.Property(x => x.DishId).HasColumnName("dish_id");
            builder.Property(x => x.ModifiedDate).HasColumnName("modified_date").HasDefaultValueSql("now()");
            builder.HasData(
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(0, 1, 0),
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(0, 2, 1),
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(0, 3, 2),
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(1, 1, 3),
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(1, 2, 4),
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(1, 3, 5),
                new RestaurantOrderApp.Domain.Entities.OrderPossibility(1, 4, 6)
            );
        }
    }
}
