using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeakyBarbers.Data.Entities;
using PeakyBarbers.Data.SeedData;
using System.Reflection;

namespace PeakyBarbers.Data
{
    public class PeakyBarbersDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        // CONSTRUCTOR
        public PeakyBarbersDbContext(DbContextOptions<PeakyBarbersDbContext> options) : base(options) { }

        // DB SETS
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<AppointmentSlot> AppointmentSlots { get; set; }

        // OnModelCreate
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // call the OnModelCreating method for the IdentityDbContext
            base.OnModelCreating(modelBuilder);

            // apply configs on entity classes
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // seed data
            SeedDataConfiguration.ConfigureSeedData(modelBuilder);
        }
    }
}
