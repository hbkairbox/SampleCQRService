using Microsoft.EntityFrameworkCore;
using SampleCQRService.Infrastructure.Entities;

namespace SampleCQRService.Infrastructure.DBContext
{
    public class ReadOnlyContext : Context, IReadOnlyContext
    {
        public new IQueryable<Category> Categories => base.Categories.AsQueryable();

        public ReadOnlyContext(DbContextOptions<Context> options)
                : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [Obsolete("This context is read-only", true)]
        public new int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new int SaveChanges(bool acceptAll)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }

    public interface IReadOnlyContext : IDisposable
    {
        IQueryable<Category> Categories { get; }
    }

}
