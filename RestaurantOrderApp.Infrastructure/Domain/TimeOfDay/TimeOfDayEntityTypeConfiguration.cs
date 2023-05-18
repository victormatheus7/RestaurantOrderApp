using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantOrderApp.Infrastructure.Domain.TimeOfDay
{
    internal sealed class TimeOfDayEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantOrderApp.Domain.Entities.TimeOfDay>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderApp.Domain.Entities.TimeOfDay> builder)
        {
            builder.ToTable("times_of_day");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().HasColumnName("id");
            builder.Property(x => x.Name).HasMaxLength(50).HasColumnName("name");
            builder.Property(x => x.ModifiedDate).HasColumnName("modified_date").HasDefaultValueSql("now()");
        }
    }
}
