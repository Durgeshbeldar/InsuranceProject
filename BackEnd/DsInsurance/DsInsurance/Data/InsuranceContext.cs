using DsInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Data
{
    public class InsuranceContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //******* User ***********
            // Unique constraint for UserName

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Unique constraint for Email

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);





        }
    }
}
