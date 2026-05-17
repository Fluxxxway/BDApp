using BDApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ConstructionProject> Projects { get; set; }
        public DbSet<ConstructionWorker> Workers { get; set; }
        public DbSet<Material> Materials { get; set; }
    }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Component> Components => Set<Component>();
        public DbSet<ComponentFile> ComponentFiles => Set<ComponentFile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Component>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Components)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponentFile>()
                .HasOne(cf => cf.Component)
                .WithMany(c => c.Files)
                .HasForeignKey(cf => cf.ComponentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity is Project || e.Entity is Component || e.Entity is ComponentFile))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}