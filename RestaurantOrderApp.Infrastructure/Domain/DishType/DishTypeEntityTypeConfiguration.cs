using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantOrderApp.Infrastructure.Domain.DishType
{
    internal sealed class DishTypeEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantOrderApp.Domain.Entities.DishType>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderApp.Domain.Entities.DishType> builder)
        {
            builder.ToTable("dish_types");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().HasColumnName("id");
            builder.Property(x => x.Name).HasMaxLength(50).HasColumnName("name");
            builder.Property(x => x.ModifiedDate).HasColumnName("modified_date").HasDefaultValueSql("now()");
            builder.HasData(
                new RestaurantOrderApp.Domain.Entities.DishType(1, "entrée"),
                new RestaurantOrderApp.Domain.Entities.DishType(2, "side"),
                new RestaurantOrderApp.Domain.Entities.DishType(3, "drink"),
                new RestaurantOrderApp.Domain.Entities.DishType(4, "dessert")
            );
        }
    }
}
