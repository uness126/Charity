using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharityApi.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.Property(t => t.Phone)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(t=>t.Mobile)
            .HasMaxLength(11)
            .IsRequired();
    }
}
