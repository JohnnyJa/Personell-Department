using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PersonnelDepartmentContext : DbContext
    {

        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Division> Divisions { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PersonnelDepartment;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasMany(d => d.Projects)
                .WithMany(p => p.Workers)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectWorker",
                    l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId")
                        .HasConstraintName("FK_ProjectWorker_Projects"),
                    r => r.HasOne<Worker>().WithMany().HasForeignKey("WorkerId")
                        .HasConstraintName("FK_ProjectWorker_Workers"),
                    j =>
                    {
                        j.HasKey("ProjectId", "WorkerId").IsClustered(false);

                        j.ToTable("ProjectWorkers");

                        j.IndexerProperty<int>("ProjectId").HasColumnName("ProjectId");

                        j.IndexerProperty<int>("WorkerId").HasColumnName("WorkerId");
                    });
        }
    }
}