using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantOrderApp.Infrastructure.Domain.Order
{
    internal sealed class OrderEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantOrderApp.Domain.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderApp.Domain.Entities.Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(x => new { x.Id, x.Sequence });
            builder.Property(x => x.Id).HasColumnName("guid");
            builder.Property(x => x.Sequence).HasColumnName("sequence");
            builder.Property(x => x.TimeOfDayId).HasColumnName("time_of_day_id");
            builder.Property(x => x.DishTypeId).HasColumnName("dish_type_id");
            builder.Property(x => x.DishId).HasColumnName("dish_id");
            builder.Property(x => x.ModifiedDate).HasColumnName("modified_date").HasDefaultValueSql("now()");
            builder.Ignore(x => x.DishType);
        }
    }
}
