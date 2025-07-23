using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Infrastructure.Configuration
{
    public class UserBranchConfiguration : IEntityTypeConfiguration<UserBranch>
    {
        public void Configure(EntityTypeBuilder<UserBranch> builder)
        {
            builder.HasKey(ub => new { ub.UserId, ub.BranchId });

            builder.HasOne(ub => ub.User)
                   .WithMany(u => u.UserBranches)
                   .HasForeignKey(ub => ub.UserId);

            builder.HasOne(ub => ub.Branch)
                   .WithMany(b => b.UserBranches)
                   .HasForeignKey(ub => ub.BranchId);

            builder.Property(ub => ub.Role)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
