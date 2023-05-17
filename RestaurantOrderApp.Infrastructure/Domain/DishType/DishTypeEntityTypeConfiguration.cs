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
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasMaxLength(50).HasColumnName("name");
        }
    }
}
