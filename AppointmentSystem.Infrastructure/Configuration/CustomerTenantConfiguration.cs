using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Infrastructure.Configuration
{
    public class CustomerTenantConfiguration : IEntityTypeConfiguration<CustomerTenant>
    {
        public void Configure(EntityTypeBuilder<CustomerTenant> builder)
        {
            builder.HasKey(ct => new { ct.CustomerId, ct.TenantId });

            builder.HasOne(ct => ct.Customer)
                .WithMany(c => c.CustomerTenants)
                .HasForeignKey(ct => ct.CustomerId);

            builder.HasOne(ct => ct.Tenant)
                .WithMany(t => t.CustomerTenants)
                .HasForeignKey(ct => ct.TenantId);
        }
    }
}
