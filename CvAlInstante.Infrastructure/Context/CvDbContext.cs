using CvAlInstante.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CvAlInstante.Infrastructure.Context;

public class CvDbContext : DbContext
{
    public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) { }

    public DbSet<Resume> Resumes => Set<Resume>();
    public DbSet<EducationRecord> EducationRecords => Set<EducationRecord>();
    public DbSet<WorkExperience> WorkExperiences => Set<WorkExperience>();
    public DbSet<Skill> Skills => Set<Skill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relationships
        modelBuilder.Entity<Resume>()
            .HasMany(r => r.EducationRecords)
            .WithOne(e => e.Resume!)
            .HasForeignKey(e => e.ResumeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Resume>()
            .HasMany(r => r.WorkExperiences)
            .WithOne(e => e.Resume!)
            .HasForeignKey(e => e.ResumeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Resume>()
            .HasMany(r => r.Skills)
            .WithOne(s => s.Resume!)
            .HasForeignKey(s => s.ResumeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Constraints & configuration

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.Property(x => x.FullName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Degree)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.ProfessionalSummary)
                .HasMaxLength(2000);
            
            entity.Property(x => x.Email)
                .HasMaxLength(100);
            
            entity.Property(x => x.Phone)
                .HasMaxLength(20);
            
            entity.Property(x => x.Location)
                .HasMaxLength(100);
            
            entity.Property(x => x.LinkedIn)
                .HasMaxLength(200);
            
            entity.Property(x => x.Portfolio)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<EducationRecord>(entity =>
        {
            entity.Property(x => x.Institution)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.Property(x => x.Company)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Role)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(1500)
                .IsRequired();
            
            entity.Property(x => x.Achievements)
                .HasMaxLength(1500);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Level)
                .HasDefaultValue(1)
                .IsRequired();
        });
    }
}
