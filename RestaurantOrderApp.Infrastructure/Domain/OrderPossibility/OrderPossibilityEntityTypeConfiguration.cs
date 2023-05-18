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
        }
    }
}
