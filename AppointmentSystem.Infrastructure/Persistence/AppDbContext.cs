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
        public DbSet<User> Users { get; set; }

        public DbSet<TenantUser> TenantUsers { get; set; }

        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerTenant> CustomersTenant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BranchConfiguration());

            modelBuilder.ApplyConfiguration(new TenantConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new TenantUserConfiguration());

            modelBuilder.ApplyConfiguration(new UserBranchConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerTenantConfiguration());




        }
    }

}
