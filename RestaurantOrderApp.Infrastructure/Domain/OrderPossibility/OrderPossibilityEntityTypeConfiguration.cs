using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantOrderApp.Infrastructure.Domain.OrderPossibility
{
    internal sealed class OrderPossibilityEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantOrderApp.Domain.Entities.OrderPossibility>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderApp.Domain.Entities.OrderPossibility> builder)
        {
            builder.ToTable("order_possibilities");
            builder.HasKey(x => x.TimeOfDay.Id);
            builder.HasKey(x => x.DishType.Id);
            builder.Property(x => x.TimeOfDay.Id).HasColumnName("time_of_day_id");
            builder.Property(x => x.DishType.Id).HasColumnName("dish_type_id");
            builder.Property(x => x.Dish.Id).HasColumnName("dish_id");
        }
    }
}
