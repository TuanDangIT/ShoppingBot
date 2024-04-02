using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ShoppingBot.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Interceptors
{
    internal class UpdateAuditableInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                UpdateAuditableEntities(eventData.Context);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private static void UpdateAuditableEntities(DbContext context)
        {
            DateTime utcNow = DateTime.UtcNow;
            var entities = context.ChangeTracker.Entries<IAuditable>().ToList();

            foreach (EntityEntry<IAuditable> entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    SetCurrentPropertyValue(
                        entry, nameof(IAuditable.CreatedAt), utcNow);
                }

                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    SetCurrentPropertyValue(
                        entry, nameof(IAuditable.LastUpdatedAt), utcNow);
                }
            }

            static void SetCurrentPropertyValue(
                EntityEntry entry,
                string propertyName,
                DateTime utcNow) =>
                entry.Property(propertyName).CurrentValue = utcNow;
        }
    }
}
