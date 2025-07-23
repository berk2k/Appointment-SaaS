using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Infrastructure.Configuration
{
    public class AppointmentHistoryConfiguration : IEntityTypeConfiguration<AppointmentHistory>
    {
        public void Configure(EntityTypeBuilder<AppointmentHistory> builder)
        {
            builder.HasKey(ah => ah.AppointmentHistoryId);

            builder.Property(ah => ah.PropertyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ah => ah.OldValue)
                .HasMaxLength(1000);

            builder.Property(ah => ah.NewValue)
                .HasMaxLength(1000);

            builder.Property(ah => ah.ChangedAt)
                .IsRequired();

            builder.HasOne(ah => ah.Appointment)
                .WithMany(a => a.History)
                .HasForeignKey(ah => ah.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ah => ah.ChangedByUser)
                .WithMany()
                .HasForeignKey(ah => ah.ChangedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
