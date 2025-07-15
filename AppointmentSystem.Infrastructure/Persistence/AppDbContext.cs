using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BranchConfiguration());

            modelBuilder.ApplyConfiguration(new TenantConfiguration());
        }
    }

}
