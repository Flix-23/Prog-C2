using HospitalApi.models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Hospital> Hospitals => Set<Hospital>();
        public DbSet<Patient> Patients => Set<Patient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.Patients)
                .WithOne(p => p.Hospital)
                .HasForeignKey(p => p.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
