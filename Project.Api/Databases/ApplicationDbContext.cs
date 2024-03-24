using Microsoft.EntityFrameworkCore;
using Project.Domain.Models.Commons;

namespace Project.Api.Databases
{
    public partial class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Get all the entities that inherit from BaseAuditableEntity
            // and have a state of Added or Modified
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseAuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseAuditableEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                    ((BaseAuditableEntity)entry.Entity).CreatedBy = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApplication"; 
                }
                else
                {
                    Entry((BaseAuditableEntity)entry.Entity).Property(e => e.CreatedAt).IsModified = false;
                    Entry((BaseAuditableEntity)entry.Entity).Property(e => e.CreatedBy).IsModified = false;
                }

                ((BaseAuditableEntity)entry.Entity).ModifiedAt = DateTime.UtcNow;
                ((BaseAuditableEntity)entry.Entity).ModifiedBy = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApplication";

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
