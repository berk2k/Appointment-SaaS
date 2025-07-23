using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Infrastructure.Configuration
{
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasKey(tu => new { tu.TenantId, tu.UserId });

            builder.HasOne(tu => tu.Tenant)
                   .WithMany(t => t.TenantUsers)
                   .HasForeignKey(tu => tu.TenantId);

            builder.HasOne(tu => tu.User)
                   .WithMany(u => u.TenantUsers)
                   .HasForeignKey(tu => tu.UserId);

            builder.Property(tu => tu.Role)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
