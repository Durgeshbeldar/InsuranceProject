using DsInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Data
{
    public class InsuranceContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<InsuranceScheme> InsuranceSchemes { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<Nominee> Nominees { get; set; }
        public DbSet<PolicyAccount> PolicyAccounts { get; set; }
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //******* User ***********
        
            //modelBuilder.Ignore<PolicyAccount>();
            modelBuilder.Entity<PolicyAccount>()
                .HasOne(pa => pa.Customer)
                .WithMany()
                .HasForeignKey(pa => pa.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PolicyAccount>()
                .HasOne(pa => pa.Agent)
                .WithMany()
                .HasForeignKey(pa => pa.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PolicyAccount>()
                .HasOne(pa => pa.InsuranceScheme)
                .WithMany()
                .HasForeignKey(pa => pa.SchemeId)
                .OnDelete(DeleteBehavior.NoAction);



            //  // No cascading delete

            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InsuranceScheme>()
          .HasOne<InsurancePlan>() // Note: We don't need to mention InsurancePlan property since it's not in the model
          .WithMany() // No reference back to InsuranceScheme
          .HasForeignKey(scheme => scheme.PlanId)
          .OnDelete(DeleteBehavior.NoAction);




            // Unique constraint



            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<State>()
                .HasIndex(state=>state.Name).IsUnique();

            modelBuilder.Entity<City>().
                HasIndex(City=> City.Name).IsUnique();

            base.OnModelCreating(modelBuilder);





        }
    }
}
