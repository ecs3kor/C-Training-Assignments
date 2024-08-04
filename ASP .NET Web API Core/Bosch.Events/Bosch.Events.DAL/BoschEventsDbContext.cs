using Bosch.Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Bosch.Events.DAL
{
    public class BoschEventsDbContext : DbContext
    {
        public BoschEventsDbContext()
        {
            
        }
        public BoschEventsDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EventRegistration> EventRegistration { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>().HasKey("EventId", "EmployeeId");
            modelBuilder.Entity<Feedback>().HasKey("EventId", "EmployeeId");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = KOR-C-002EU\SQLEXPRESS; Initial Catalog = BoschEventsDb; Trusted_Connection = true; TrustServerCertificate = True;");
            }
            
        }

    }
}
