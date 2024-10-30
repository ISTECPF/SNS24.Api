using Microsoft.EntityFrameworkCore;
using SNS24.WebApi.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SNS24.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalLeave> MedicalLeaves { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).Updated = DateTime.UtcNow;
            }
        }
    }
}
