using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Infrastructure.Configuration
{
    public class AppointmentServiceConfiguration : IEntityTypeConfiguration<AppointmentService>
    {
        public void Configure(EntityTypeBuilder<AppointmentService> builder)
        {
            builder.HasKey(asv => new { asv.AppointmentId, asv.ServiceId });

            builder.HasOne(asv => asv.Appointment)
                .WithMany(a => a.AppointmentServices)
                .HasForeignKey(asv => asv.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(asv => asv.Service)
                .WithMany(s => s.AppointmentServices)
                .HasForeignKey(asv => asv.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
