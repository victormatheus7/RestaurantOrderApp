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
        }
    }
}
